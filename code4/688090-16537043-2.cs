     public bool TryMe()
     {
      try
       {
        SomeMethod();
        return true;
       }
       catch (Exception exception)
       {
        // log exception 
        return false;
       }
      }
