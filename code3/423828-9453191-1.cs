        [JsonConverter(typeof(CountryModelConverter))]
        public class CountryModel
        {
            public int Page { get; set; }
            public int Pages { get; set; }
            public int Per_Page { get; set; }
            public int Total { get; set; }
            public List<Country> Countries { get; set; }
        }
        public class Country
        {
            public string Id { get; set; }
            public string Iso2Code { get; set; }
            public string Name { get; set; }
            public Region Region { get; set; }
        }
        public class Region
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }
