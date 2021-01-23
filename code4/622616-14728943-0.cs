    [DataContract]
    public class Foo
    {
        [DataMember]
        public string NonIgnoredProperty { get; set; }
        
        [IgnoreDataMember]
        public string IgnoredProperty { get; set; }
        
        // ....
    }
