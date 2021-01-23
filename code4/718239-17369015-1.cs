    [Serializable, DataContract(Namespace = "Company.Domain.LOB.Handler")]
    [Flags]
    public enum BankItemStatus
    {
        [EnumMember]
        UnBatched,
        [EnumMember]
        Batched,
        [EnumMember]
        Sent,
        [EnumMember]
        ReplyReceived,
        [EnumMember]
        Closed
    }
