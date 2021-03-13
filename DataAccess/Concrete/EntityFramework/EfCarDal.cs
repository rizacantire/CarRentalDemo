using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (var context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto()
                             {
                                 ColorName = co.Name,
                                 BrandName = b.Name,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
