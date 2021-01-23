    public class Foo
    {
        public Guid Id { get; set; }
        public string Guid { get; set; }
        [JsonIgnore]
        public List<Something> Somethings { get; set; }
    }
