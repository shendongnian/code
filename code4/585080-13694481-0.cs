    public static class CountryEntries
        {
            public static IEnumerable<Country> GetCountries()
            {
                return from ri in
                           from ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                           select new RegionInfo(ci.LCID)
                           orderby ri.DisplayName
                       group ri by ri.TwoLetterISORegionName into g                       
                       select new Country
                       {
                           CountryId = g.Key,
                           Title = g.First().DisplayName
                       };
            }
            public class Country
            {
                public string CountryId { get; set; }
                public string Title { get; set; }
            }
        }
