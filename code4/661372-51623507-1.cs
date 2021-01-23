    public class Datum
    {
        public string key1 { get; set; }
        public string key2 { get; set; }
    }
    
    public class RootObject
    {
        public string id { get; set; }
        public List<Datum> data { get; set; }
    }
