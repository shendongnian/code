    [DataContract]
    public class OpenExchangeRatesResult
    {
        public OpenExchangeRatesResult() { }
        [DataMember]
        public string disclaimer { get; set; }
        [DataMember]
        public Dictionary<string, decimal> rates { get; set; }
    }
