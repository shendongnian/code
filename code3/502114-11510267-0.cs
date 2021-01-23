    [DataContract(Name = "Occurrence", Namespace = "")]
    class Occurrence
    {
        [DataMember]
        public string CategoryList { get; set; }
        [DataMember]
        public string ContactEmail { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
