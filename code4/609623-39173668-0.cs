    [JsonObject]
    class FooCollection : IList<Foo> {
        [JsonProperty]
        private List<Foo> _foos = new List<Foo>();
        public string Bar { get; set; }  
        // IList implementation
        [JsonIgnore]
        public int Count { ... }
        [JsonIgnore]
        public bool IsReadOnly { ... }
    }
