    public class MySingleton
    {
       private static MySingleton instance;
    
       private MySingleton() {}
    
       public static MySingleton Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new MySingleton();
             }
             return instance;
          }
       }
    }
