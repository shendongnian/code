    public class Money
    {
        public string Currency { get; set; }
        [IgnoreDataMember]
        public decimal Amount { get; set; }
        [DataMember(Name = "Amount")]
        public decimal RoundedAmount { get{ return Math.Round(Amount, 2); } }
    }
