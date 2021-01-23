    public class Worker
    {
         [JsonProperty("result")]
         public Result Result { get; set; }
    }
    
    public class Result
    {
        [JsonProperty("success")]
        public string Success { get; set; }
    
        [JsonProperty("value")]
        public string Value { get; set; }
    }
