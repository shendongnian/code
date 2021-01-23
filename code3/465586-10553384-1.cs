    List<TopSellingCountries> tsc = (from sale in Sales
                                     where sale.CountryCode != null
                                     group sale by sale.CountryCode into cc
                                     order by cc.Count() descending
                                     select new TopSellingCountries
                                     {
                                         CountryCode = cc.Key,
                                         CountryCount = cc.Count()
                                     }).Take(10).ToList();
