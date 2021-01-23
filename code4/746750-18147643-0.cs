    public class ApiMessage
    {
        public string P1 { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string P2 { get; set; }
    }
