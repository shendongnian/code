    class MyClass
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> name;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> midname { get; set; }
    }
