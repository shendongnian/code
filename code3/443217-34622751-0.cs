    [DataContract]
    public class Response
    {
        [DataMember(Name = "status", IsRequired=true)]
        public STATUS Status { get; set; }
    
        [DataMember(Name = "message", IsRequired = true)]
        public string Message { get; set; }
    
        [DataMember(Name = "data", IsRequired = true)]
        public dynamic Data { get; set; }
    }
