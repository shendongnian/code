    public class AccountService : Service
    {
        public AccountService()
        {
        }
        public object Any(AccountTest test)
        {
            return "hello";
        }
        public object Any(AllAccounts request)
        {
            var ret = new List<Account> { new Account() { Id = 3 } };
            return ret;
        }
    }
