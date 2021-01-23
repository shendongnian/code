    [DataContract( Namespace = "http://enes.com/" )]
    public class CompositeTypeClient
    {
        [DataMember]
        public bool BoolValue { get; set; }
        [DataMember]
        public string StringValue { get; set; }
    }
