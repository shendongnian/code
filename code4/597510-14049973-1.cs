    public class Category
    {
        public string id { get; set; }
        public string title { get; set; }
        public string href { get; set; }
        public string type { get; set; }
    }
    
    public class Item
    {
        public List<double> position { get; set; }
        public int distance { get; set; }
        public string title { get; set; }
        public Category category { get; set; }
        public string icon { get; set; }
        public string vicinity { get; set; }
        public List<object> having { get; set; }
        public string type { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public double? averageRating { get; set; }
    }
    
    public class Results
    {
        public List<Item> items { get; set; }
    }
    
    public class Location
    {
        public List<double> position { get; set; }
    }
    
    public class Context
    {
        public Location location { get; set; }
        public string type { get; set; }
    }
    
    public class Search
    {
        public Context context { get; set; }
    }
    
    public class RootObject
    {
        public Results results { get; set; }
        public Search search { get; set; }
    }
