    public class Poco
    {
            [JsonProperty("myid")]
            public string Id{ get; set; }
            
            [JsonProperty("properties")]
            [JsonConverter(typeof(DictionaryToJsonObjectConverter))]
            public IDictionary<string, string> Properties { get; set; }
        }
