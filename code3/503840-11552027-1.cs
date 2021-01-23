    public class SomeException : Exception {}
    public void SomeMethod()
    {
      try
      {
         // code
      }
      catch(Exception e)
      { 
          throw new SomeException ("an error in somemethod",e);
      }
    }
