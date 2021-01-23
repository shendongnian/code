    public class Worker
    {
         [JsonProperty("result")]
         public Result result { get; set; }
    }
    
    public class Result
    {
        [JsonProperty("success")]
        public string success { get; set; }
    
        [JsonProperty("value")]
        public string value { get; set; }
    }
