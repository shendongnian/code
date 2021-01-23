    public partial static class Aspect
    {
      public static T CallClient<T>( Func<Client, T> fn )
      {
        using ( var client = ... create client ... )
        {
          return fn( client );
        }
      }
    }
