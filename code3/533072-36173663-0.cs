    public sealed class Singleton
    {
       private static volatile Singleton instance;
       private static object lockObj = new Object();
    
       private Singleton() {}
    
       public static Singleton Instance
       {
          get 
          {
             if (instance == null) 
             {
                lock (lockObj) 
                {
                   if (instance == null) 
    			   {
                      instance = new Singleton();
    			   }
                }
             }
             return instance;
          }
       }
    }
