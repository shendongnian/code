    [DataServiceEntity]
    [DataContract]
    public class MyClass
    {
        [DataMember]
        public string PartitionKey { get; set; }
    
        [DataMember]
        public string RowKey { get; set; }
    
        [DataMember]
        public DateTime Timestamp { get; set; }
    }
