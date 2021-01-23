    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RootObject
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "display")]
        public string Display { get; set; }
        [JsonProperty(PropertyName = "genetics")]
        public List<string> Genetics { get; set; }
        [JsonProperty(PropertyName = "price")]
        public List<string> Price { get; set; }
        [JsonProperty(PropertyName = "form")]
        public string Form { get; set; }
    }
