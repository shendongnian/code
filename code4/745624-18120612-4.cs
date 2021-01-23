    public class RootObject
    {
        public Response response { get; set; }
    }
    public class Response
    {
        public int errorFlag { get; set; }
        [JsonProperty("Score Detail")]
        public JObject ScoreDetail { get; set; }
    }
