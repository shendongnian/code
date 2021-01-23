    [DataContract(Namespace = "")]
    public class Identifier
    {
        [DataMember]
        public string Version { get; set; }
    
        [DataMember]
        public string Value { get; set; }
    
        [DataMember]
        public int IdentifierType { get; set; }
    }
