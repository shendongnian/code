    protected bool Authenticate(string username, string password) {
      //...
    }
    protected bool DoAuthenticate<T>(NetworkClient nc, string username, string password) where T : NetworkClient {
    //Do a cast into the sub class.
      T subInst = (T) nc;
      return nc.Authenticate(username, password);
    }
    
 
