    public class MyModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int experience {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool status {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string uuid {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object property_1 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object property_2 {get;set;}
        ...
    }
