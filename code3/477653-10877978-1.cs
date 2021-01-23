    public class Header
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public string Timestamp { get; set; }
    }
    
    public class League
    {
        public string Name { get; set; }
        public string TargetURL { get; set; }
        public string Total { get; set; }
    }
    
    public class Country
    {
        public List<League> League { get; set; }
        public string Name { get; set; }
        public string TargetURL { get; set; }
        public string Total { get; set; }
    }
    
    public class Sport
    {
        public Country Country { get; set; }
        public string Name { get; set; }
        public string Total { get; set; }
    }
    
    public class Results
    {
        public Sport Sport { get; set; }
    }
    
    public class Test
    {
        public Header Header { get; set; }
        public Results Results { get; set; }
    }
    public class TestRootObject
    {
        public Test Test { get; set; }
    }
