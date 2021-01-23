    public class Singleton
    {
       private static Singleton instance;
       private bool isCanceled;
       private Singleton() 
       {
           isCanceled = false;
       }
    
       public static Singleton Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new Singleton();
             }
             return instance;
          }
       }
       public bool IsCanceled
       {
          get 
          {
             return isCanceled;
          }
          set
          {
             isCanceled = value;
          }
       }
    }
