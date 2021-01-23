    List<User> SomeMethod()
    {
      List<User> = List<User>();
       ...
       return userList;
    }
    
    var task = Task<List<User>>.Factory.StartNew(SomeMethod, TaskCreationOptions.LongRunning);
