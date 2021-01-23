    public class Account
    {
        XElement self;
        public Account(XElement account)
        { 
            if(null == account)
                self = new XElement("Account");
            else
                self = account; 
        }
    
        public int Number
        {
            get { return self.Get("acctnum", 0); }
            set { self.Set("acctnum", value, false); }
        }
    
        public Charges Charges { get { return new Charges(self.GetElement("Charges")); } }
    }
