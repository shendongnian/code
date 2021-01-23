    public class RootObject
    {
        [JsonProperty("@companyName")]
        public string companyName { get; set; }
        [JsonProperty("@version")]
        public string version { get; set; }
        [JsonProperty("@generatedDate")]
        public string generatedDate { get; set; }
        public List<Application> application { get; set; }
    }
    public class Application
    {
        [JsonProperty("@name")]
        public string name { get; set; }
        [JsonProperty("@apiKey")]
        public string apiKey { get; set; }
        [JsonProperty("@createdDate")]
        public string createdDate { get; set; }
        [JsonProperty("@platform")]
        public string platform { get; set; }
    }
