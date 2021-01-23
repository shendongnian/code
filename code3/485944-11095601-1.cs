    public class AccountManipulator
    {
        private  AccountFactory _factory;
        private UserRepository _users;
    
        public AccountManipulator(AccountFactory factory, UserRepository users)
        {
           _factory = factory;
           _users = users;
        }
    
        public void FreezeAccount(int accountNumber)
        {
           var acc = _factory.GetAccount(accountNumber);
           acc.Freeze();
        }
    
        public IEnumerable<IAccount> GetAccountsOf(User user) {
           return _users.GetAccountIds(user).Select(_factory.GetAccount);
        }
    }
    
    public interface UserRepository {
        IEnumerable<int> GetAccountIds(User user);
    }
