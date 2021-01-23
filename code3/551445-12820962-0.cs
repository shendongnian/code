    interface IPostUrl
    {
        string postUrl { get; }
    }
    class paymentBase
    {
        public int transactionId {get;set;}
        public string item {get;set;}
        public void payme(){}
    }
    class paymentGateWayNamePayment : paymentBase, IPostUrl
    {
        public string postUrl
        {
            get { return "http://myurl.com/payme"; }
        }
    }
