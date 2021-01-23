    public class From
    {
        public string id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
    }
    
    public class Privacy
    {
        public string value { get; set; }
    }
    
    public class Datum
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    
    public class Likes
    {
        public List<Datum> data { get; set; }
    }
    
    public class RootObject
    {
        public string id { get; set; }
        public From from { get; set; }
        public string message { get; set; }
        public Privacy privacy { get; set; }
        public string type { get; set; }
        public string status_type { get; set; }
        public string created_time { get; set; }
        public string updated_time { get; set; }
        public Likes likes { get; set; }
    }
