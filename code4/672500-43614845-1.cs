    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class SearchedData
    {
        [JsonProperty(PropertyName = "Currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "Routes")]
        public List<List<Route>> Routes { get; set; }
    }
