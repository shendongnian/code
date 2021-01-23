    public class Item2
    {
        public string id { get; set; }
        public string text { get; set; }
    }
    
    public class Item
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<Item2> item { get; set; }
    }
    
    public class RootObject
    {
        public int id { get; set; }
        public List<Item> item { get; set; }
    }
