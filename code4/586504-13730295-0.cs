    [JsonObject(MemberSerialization.OptIn)]
    public class LinksJSON
    {
        [JsonProperty]
        public body body { get; set; }
        [JsonProperty]
        public string message { get; set; }
        [JsonProperty]
        public string error { get; set; }
        [JsonProperty]
        public bool status { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class body
    {
        [JsonProperty]
        public link link { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class link
    {
        [JsonProperty]
        public string[] linkurl { get; set; }
    }
