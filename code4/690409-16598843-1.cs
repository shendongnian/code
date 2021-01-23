    public class ResponseData
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    
        [JsonConverter(typeof(PostsConverter))]
        [JsonProperty("items")]
        public List<IPost> Items { get; set; }
    }
