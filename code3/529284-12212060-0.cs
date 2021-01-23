    // Repository (non-generic)
    private IQueryable<User> GetUser()
    {
      var results = from u in _db.Users
                    select new User
                    {
                      ID = u.ID,
                      Username = u.Username,
                      // and so on
                    };
    
      return results;
    }
    //Service Layer  
    private User GetUser(string Username)
    {
       User u = _repository.GetUser().WithUsername(username);
    } 
    // Extension Method
    public static IQueryable<User> WithUsername(this IQueryable<User> qry, string username)
    {
      return from u in qry
             where u.Username == username
             select u;
    }
