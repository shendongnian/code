<!-- -->
    public class Child
    {
        [JsonProperty(PropertyName = "children")]
        public List<Child> Children { get; set; }
        [JsonProperty(PropertyName = "date_added")]
        public string DateAdded { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "date_modified")]
        public string DateModified { get; set; }
    }
