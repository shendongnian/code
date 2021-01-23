    public class Note
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "data")]
        public Data[] Data { get; set; }
    }
    public class Data
    {
        [JsonProperty(PropertyName = "modifydate")]
        public float ModifyDate { get; set; }
 
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
