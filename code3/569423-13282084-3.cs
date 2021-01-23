    public abstract class BaseContext : DbContext, IDataContext
    {
      //To allow multiple contexts sharing the same connection string
      protected BaseContext(): base("name=MyConnectionString") {}
    }
    
    public class AccountContext : BaseContext, IAccountContext {}
    
    //With this, I can have simple repositories:
    
    public class UserRepository : BaseRepository<AccountContext, User>
    { //All implementation comes from the base abstract class, unless I need to change it (override methods)
    }
