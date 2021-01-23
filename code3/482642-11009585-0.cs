    public class YahooField
        {
            [JsonProperty("created")]
            public string Created { get; set; }
    
            [JsonProperty("updated")]
            public string Updated { get; set; }
    
            [JsonProperty("uri")]
            public string Uri { get; set; }
    
            [JsonProperty("id")]
            public string Id { get; set; }
    
            [JsonProperty("type")]
            public string Type { get; set; }
    
            [JsonProperty("value")]
            public ValueField Value { get; set; }
    
            [JsonProperty("editedBy")]
            public string EditedBy { get; set; }
    
            [JsonProperty("isConnection")]
            public string IsConnection { get; set; }
        }
