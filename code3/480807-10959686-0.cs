    using System;
    
    public class MainInterface : Form
    {
       private static MainInterface Current;
    
       private MainInterface ()
       {
          if ( LoginForm . Instance != null )
             LoginForm . Instance . Close ();
       }
    
       public static MainInterface Instance
       {
          get 
          {
             if (Current == null)
             {
                Current = new MainInterface ();
             }
             return Current;
          }
       }
    }
