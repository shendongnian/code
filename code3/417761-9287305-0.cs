    [DataContract]
    class DataItem
    {
        [DataMember(Order = 1)]
        public string Id { get; set; }
        [DataMember(Order = 2)]
        public string DataValue { get; set; }
        [DataMember(Order = 3)]
        public string CreatedDateTime { get; set; }
    }
