    public class DealerResponse
    {
        public bool valid { get;set; }
        List<Dealer> data { get;set; }
    }
    public class Dealer
    {
        public string dealerId;         
        public string branchId;   
    }
