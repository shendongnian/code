    lock(someLock)
    {
        dispatcher.Invoke(SomeMethod);
    }
    
    //...
    
    public void SomeMethod()
    {
      lock(someLock)
      {
      //... do some work here
      }
    }
