    List<TopSellingCountries> tsc = (from sale in Sales
                                     where sale.CountryCode != null
                                     group sale by sale.CountryCode.Trim() into cc
                                     select new TopSellingCountries
                                     {
                                         CountryCode = cc.Key,
                                         CountryCount = cc.Count()
                                     })
                                     .OrderByDescending(c => c.CountryCount)
                                     .Take(10)
                                     .ToList();
