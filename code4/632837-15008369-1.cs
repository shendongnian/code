    using System;
    
    public class Singleton
    {
       private static Singleton instance;
    
       private Singleton() {}
    
       public static Singleton Instance
       {
          get 
          {
             lock
             {
               if (instance == null)
               {
                  instance = new Singleton();
               }
               return instance;
             }
          }
       }
    }
