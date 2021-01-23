    public static User CreateUser(string name)
    {
          // Check whether user already exists, if so, throw exception / return null
    
          // If name didn't exist, record that this user name is now taken.
          // Construct and return the user object
          return new User(name);
    }
    
    private User(string name)
    {
           this.Name = name;
    }
