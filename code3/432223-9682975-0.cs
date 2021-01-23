    public class Country
    {
        public string Code { get; set; } //country ID would not make sense in this approach
        public string Name { get; set; }
    }
    public class Region
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; } //1 region is assigned to only 1 country
    }
    public class City
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RegionCode { get; set; } //1 city is assigned to only 1 region
    }
