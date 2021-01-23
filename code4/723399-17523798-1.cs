    [DataContract]
    public class JsonModel
    {
        [DataMember(Name = "statusCode")]
        public int StatusCode { get; set; }
        [DataMember(Name = "statusDescription")]
        public string StatusDescription { get; set; }
        [DataMember(Name = "traceId")]
        public string TraceId { get; set; }
        ...
    }
