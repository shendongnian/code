    [MessageContract]
    public class Trailer
    {
        [MessageBodyMember(Order=1)]
        public string TrailerID { get; set; }
        [MessageBodyMember]
        public List<Shipment> Contents { get; set; }
        public Trailer()
        {
            this.Contents = new  List<Shipment>();
        }
    }
    public class Shipment
    {
        [MessageBodyMember(Order = 1)]
        public string ASNNumber { get; set; }
        [MessageBodyMember(Order = 2)]
        public string SupplierCode { get; set; }
        [MessageBodyMember(Order = 3)]
        public string Loc { get; set; }
        [MessageBodyMember(Order = 4)]
        public string CarrierCode { get; set; }
        [MessageBodyMember(Order = 5)]
        public string CarrierProNo { get; set; }
        [MessageBodyMember(Order = 6)]
        public string BillOfLadingNo { get; set; }
        [MessageBodyMember(Order = 7)]
        public string PackageSlipNo { get; set; }
        [MessageBodyMember(Order = 8)]
        public string UpdateID { get; set; }
        [MessageBodyMember(Order = 9)]
        public string UnloadPriority { get; set; }
        [MessageBodyMember(Order = 10)]
        public string DateNeeded { get; set; }
        [MessageBodyMember(Order = 11)]
        public string OrderShipped { get; set; }
        [MessageBodyMember(Order = 12)]
        public List<Item> Items { get; set; }
        public Shipment()
        {
            this.Items = new List<Item>();
        }
    }
    public class Item
    {
        [MessageBodyMember(Order = 1)]
        public string ItemNo { get; set; }
        [MessageBodyMember(Order = 2)]
        public string OrderNo { get; set; }
        [MessageBodyMember(Order = 3)]
        public string OrderLineNo { get; set; }
        [MessageBodyMember(Order = 4)]
        public string ItemDescription { get; set; }
        [MessageBodyMember(Order = 5)]
        public string ItemQty { get; set; }
        public Item() { }
    }
