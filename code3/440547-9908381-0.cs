    public static class Context
    {
       public static Subject<string> UserChanged = new Subject<string>();
    
       private static string user;
       public static string User
       {
          get { return user; }
          set
          {
             if (user != value)
             {
                user = value;
    
                UserChanged.OnNext(user);
             }
          }
       }
    }
