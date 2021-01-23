    using System;
    
    public class LoginForm: Form
    {
       private static LoginForm Current;
    
       private LoginForm ()
       {
          if ( MainInterface . Instance != null )
             MainInterface . Instance . Close ();
       }
    
       public static LoginForm Instance
       {
          get 
          {
             if (Current == null)
             {
                Current = new LoginForm ();
             }
             return Current;
          }
       }
    }
