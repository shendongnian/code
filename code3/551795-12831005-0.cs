    public class AccountManager : Account
    {
        public AccountManager()
        {
            Accounts = new List<Account>();
        }
        public List<Account> Accounts { get; set; }
    }
