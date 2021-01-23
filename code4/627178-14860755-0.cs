    public class User
    {
        public User(IUserRepository repository, string userName)
        {
          var databaseObject = repository.list(u => u.userName = userName);
          this.userName = databaseObject.userName;
          // populate other fields
        }
    
        public bool Authenticate()
        {}
     }
