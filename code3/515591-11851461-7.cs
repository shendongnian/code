    [DataContract]
    public class Foo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        //Ignore by default
        public List<Something> Somethings { get; set; }
    }
