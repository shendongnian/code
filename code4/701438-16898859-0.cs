    public class Item
    {
        public string name { get; set; }
        public string index { get; set; }
        public string optional { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> items { get; set; }
    }
