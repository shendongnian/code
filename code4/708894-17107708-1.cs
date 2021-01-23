    public class Foo
    {
        public string Received {get; set;}
        [DataMember(Name = "Content-Type")]
        public string ContentType {get; set;}
        ... 
    }
