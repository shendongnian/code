    class paymentBase
    {
        public int transactionId {get;set;}
        public string item {get;set;}
        protected virtual postUrl { get { return String.Empty; }}
    
        public void payme();
    }
    
    class paymentGateWayNamePayment : paymentBase
    {
        protected override postUrl {get { return "http://myurl.com/payme"; } }
    }
