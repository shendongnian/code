    [DataContract]
    protected internal struct Errors
    {
        [DataMember]
        public string errorCode { get; set; }
        [DataMember]
        public string errorMessage { get; set; }
    }
