    foreach (filter in filters)
    {
          if (filter != null)  {
                if (filter.CityId != 0)      {
                    ads = ads.Where(x => x.Ad.CityId == filter.CityId);
                }
                if (filter.BusinesCategoryId != 0)      {
                    ads = ads.Where(x => x.BusinessCategoryId == filter.BusinesCategoryId);
                }
          }
    } 
    return ads.ToList()
