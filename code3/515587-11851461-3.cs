    [DataContract]
    public class Foo
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Guid { get; set; }
        //Ignore by default
        public List<Something> Somethings { get; set; }
    }
