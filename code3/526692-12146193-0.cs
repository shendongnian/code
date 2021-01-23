    public class Detailcolors
    {
        public int foocolor1 { get; set; }
        public int foocolor2 { get; set; }
        public int foocolor3 { get; set; }
        public int foocolor4 { get; set; }
        public int foocolor5 { get; set; }
    }
    
    public class Colors
    {
        public Detailcolors detailcolors { get; set; }
        public string goalcolors { get; set; }
    }
    
    public class RootObject
    {
        public Colors colors { get; set; }
    }
