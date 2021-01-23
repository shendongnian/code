    [DataContract]
    [KnownType(typeof(DateList))]
    public class SomeRootElement {
        [DataMember]
        public ICollection<DateTime> Dates { get; set; }
    }
    [CollectionDataContract(ItemName="date")]
    public class DateList : Collection<DateTime>  {}
