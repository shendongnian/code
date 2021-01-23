    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Something> Somethings { get; set; }
    }
