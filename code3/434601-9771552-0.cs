    public sealed class Singleton
    {
     private static Singleton instance = null;
     private static readonly object padlock = new object();
 
    Singleton()
     {
     }
 
    public static Singleton Instance
     {
         get
         {
             if (instance == null)
             {
                 lock (padlock)
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
