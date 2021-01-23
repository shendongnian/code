    class AccountsManagement
    {
          public List<Account> Accounts
          {
               get;
               set;
          } 
          public AccountsManagement()
          {
               Accounts = new List<Account>();
          }
          //...   
          public void Create()
          {
               Accounts.Add(new Account();
          }
          public void Create(string Description)
          {
               Accounts.Add(new Account(Description);
          }
    }
