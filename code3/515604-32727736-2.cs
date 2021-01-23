    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Something> Somethings { get; set; }
    }
