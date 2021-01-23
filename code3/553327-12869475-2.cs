    public class Customer
    {
        public Customer()
        {
            _accounts = new List<Account>();
        }
    
        public List<Account> Accounts 
        {
            get { return _accounts; }
            set { _accounts = value; }
        }
    
        private List<Account> _accounts;
    }
