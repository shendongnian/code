    public class Place
    {
        public string name { get; set; }
        public int age { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
    }
    
    public class Detail
    {
        public string state { get; set; }
        public List<Place> place { get; set; }
    }
    
    public class RootObject
    {
        public List<Detail> details { get; set; }
    }
