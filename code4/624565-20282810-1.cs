    public class BibleGatewayVerse
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }
    public class Datum
    {
        [JsonProperty("osis")]
        public string Osis { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("footnotes")]
        public object[] Footnotes { get; set; }
        [JsonProperty("crossrefs")]
        public string[] Crossrefs { get; set; }
    }
