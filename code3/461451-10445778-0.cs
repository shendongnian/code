    public class id93817
    {
        public string item_id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string time_updated { get; set; }
        public string time_added { get; set; }
        public string tags { get; set; }
        public string state { get; set; }
    }
    
    public class id935812
    {
        public string item_id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string time_updated { get; set; }
        public string time_added { get; set; }
        public string tags { get; set; }
        public string state { get; set; }
    }
    
    public class List
    {
        [JsonProperty("93817")]
        public id93817 { get; set; }
        [JsonProperty("935812")]
        public id935812 { get; set; }
    }
    
    public class RootObject
    {
        public string status { get; set; }
        public List list { get; set; }
    }
