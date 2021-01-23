    [JsonObject]
    public class Item
        {
            [JsonProperty(PropertyName = "kind")]
            public string kind { get; set; }
     ...
            [JsonProperty(PropertyName = "object")]
            public Object TheObject { get; set; }
     ...
        }
