    public partial static class Aspect
    {
      public static T HandleFaultException<T>( Func<T> fn )
      {
        try
        { 
          return fn();
        }
        catch( FaultException ex )
        {
          Logger.log(ex);
          throw;
        }
      }
    }
