    public abstract class UserService<TUser> where TUser : User
    {
      public UserDbContext<TUser> Context {get;set;} // will be initialized in constructor
      public TUser GetByUserName(string username)
      {
        return (from s in Context.Users where s.UserName.Equals(username) select s).SingleOrDefault();
      }
      // etc...
    }
