    public interface IAccountRepository
    {
       AccountEntity GetAccountFromDatabase(long id);
    }
    
    public class AccountRepository : IAccountRepository
    {
       public AccountEntity GetAccountFromDatabase(long id)
       {
          //... some DB implementation here
       }
    }
    
    public class MyClass
    {
       private readonly IAccountRepository _accountRepository;
    
       public MyClass(IAccountRepository accountRepository)
       {
          _accountRepository = accountRepository;
       }
    
       public AccountEntity GetAccountEntityBy(long id)
       {
          return _accountRepository.GetAccountFromDatabase(id)
       }
    }
