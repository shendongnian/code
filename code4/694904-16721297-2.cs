    public sealed class Singleton
    {
     
       private static volatile Singleton singleton = null;
       private static readonly object singletonLock = new object();
     
       private Singleton() {//place your code here}
     
       public static Singleton GetInstance()
       {
           if (singleton == null)
           {
               lock (singletonLock)
               {
                   if (singleton == null)
                  {
                      singleton = new Singleton();
                  }
               }
            }
 
            return singleton;
       }
    }
