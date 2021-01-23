    [DataContract]
    public class Accounts
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Qty { get; set; }
        [DataMember]
        public decimal Weight { get; set; }
        [DataMember]
        public decimal Value { get; set; }
    }
