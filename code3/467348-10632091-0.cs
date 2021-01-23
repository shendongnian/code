    [DataContract]    
    [KnownType(typeof(Subscription))]
    public abstract class SerializableTableServiceEntity
    {
        [DataMember]
        public string PartitionKey { get; set; }
        [DataMember]
        public string RowKey { get; set; }
        [DataMember]
        public DateTime Timestamp { get; set; }
    }
     [DataContract]
        public class Subscription : SerializableTableServiceEntity
        {
            [DataMember]
            public string SubscriptionId { get; set; }
            [DataMember]
            public bool IsAdmin { get; set; }
        }
