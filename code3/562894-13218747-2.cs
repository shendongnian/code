<!-- -->
    public class Roots
    {
        [JsonProperty(PropertyName = "bookmark_bar")]
        public Child BookmarkBar { get; set; }
        [JsonProperty(PropertyName = "other")]
        public Child Other { get; set; }
        [JsonProperty(PropertyName = "synced")]
        public Child Synced { get; set; }
    }
