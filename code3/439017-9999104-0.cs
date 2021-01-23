    public class MyClass
    {
       public MyEntity GetEntityBy(long id)
       {
          AccountRepository _accountRepository = new AccountRepository();
    
          return _accountRepository.GetEntityFromDatabaseBy(id);
       }
    }
