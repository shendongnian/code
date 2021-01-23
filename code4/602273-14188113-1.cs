    [DataContract(Namespace = "http://myWebService.com/endpoint")]
    public class StockListRequestData
    {
        [DataMember(Order = 0)]
        public string UserID { get; set; }
    
        [DataMember(Order = 1)]
        public string StockDatabase { get; set; }
    
        [DataMember(Order = 2)]
        public bool InStockOnly { get; set; }
    }
