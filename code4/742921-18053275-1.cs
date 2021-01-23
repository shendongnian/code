    public class City2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
    
    public class City
    {
        public City2 city { get; set; }
    }
    
    public class RootObject
    {
        public List<City> cities { get; set; }
    }
