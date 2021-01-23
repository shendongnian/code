    public class AccountServiceAdapter
    {
         private List<Accounts> _accounts
         {
              get
              {
                   if(HttpContext.Current.Cache["accounts"] == null)
                        HttpContext.Current.Cache["accounts"] = default(List<Accounts>());
                   return (List<Accounts>)HttpContext.Current.Cache["accounts"];
              }
              set
              {
                   HttpContext.Current.Cache["accounts"] = value;
              }
         }
    
         public List<AccountViewModel> FetchAccounts()
         {
              if(_accounts == default(List<Accounts>))
              {
                   //Do Fetch From Service or Persistence and set _accounts
              }
              return _accounts.Select(x => x.ConvertToViewModel()).ToList();
         }
    }
