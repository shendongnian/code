    public static User CreateUser(string name)
    {
          // Check whether user already exists, if so, throw exception / return null
    
          // If not, construct and return the user object
          return new User(name);
    }
    
    private User(string name)
    {
           this.Name = name;
    }
