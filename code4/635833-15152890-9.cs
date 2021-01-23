    public class Account
    {
        public Account()
        {
        }
    
        public string FirstName
        {
            get;
            set;
        }
    
        public string LastName
        {
            get;
            set;
        }
    
        public string EmailAddress
        {
            get;
            set;
        }
    }
    
    public class MyContext
    {
        public MyContext()
        {
        }
    
        public List<Account> Accounts
        {
            get
            {
                return _accounts;
            }
        }
        private readonly List<Account> _accounts = new List<Account>();
    }
