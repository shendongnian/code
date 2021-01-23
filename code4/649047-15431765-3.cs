    public class City
    {
        public string Name { get; set; }
        public string Parent { get; set; }
    }
    public class CityInfo
    {
        public string Name { get; set; }
        public List<CityInfo> Children { get; set; }
    }
