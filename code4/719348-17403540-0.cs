    [DataContract]
    [KnownType(typeof(CustomRequest))]
    public abstract class RequestBase
    {
        [DataMember]
        public string Id { get; set; }
    
        [DataMember]
        public RequestTypeEnum RequestType { get; set; }
    }
