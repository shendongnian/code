    public class AccountManipulator
    {
    
       public void FreezeAccount( int accountNr )
       {
            var repository = new AccountRepository();
            var account = repository.GetAccount(accountNr);
            account.Freeze();
            repository.Save(account);        
       }
    
       public ICollection<Account> GetAccountsForUser( int userId )
       {
            var repository = new AccountRepository();
            return repository.GetAccountsForUser (userId);
       }
    
    }
