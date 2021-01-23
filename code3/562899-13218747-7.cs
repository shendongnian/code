<!-- -->
    public class RootObject
    {
        [JsonProperty(PropertyName = "checksum")]
        public string Checksum { get; set; }
        [JsonProperty(PropertyName = "roots")]
        public Roots Roots { get; set; }
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }
    }
