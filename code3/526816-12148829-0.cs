    [DataContract]
    public class PurchaseOrder
    {
        [DataMember]
        public Address BillTo {get; set;}
        [DataMember]
        public Address ShipTo {get; set;};
    }
