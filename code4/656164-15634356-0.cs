    public class Country
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
    public class City
    {
        public string Name { get; set; }
        public List<Street> Streets { get; set; }
    }
    public class Street
    {
        public string Name { get; set; }
    }
