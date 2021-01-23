    public class Customer
    {
        public Customer()
        {
            _accounts = new List<Accounts>();
        }
    
        public List<Accounts> Accounts 
        {
            get { return _accounts; }
            set { _accounts = value; }
        }
    
        private List<Accounts> _accounts;
    }
