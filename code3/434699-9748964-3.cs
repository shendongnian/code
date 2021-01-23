    public class MySingleton
    {
      private static MySingleton Instance{ get; set; }
      private static readonly object initLock;
    
      // Private constructor
      private MySingleton()
      {
        initLock = new object();
      }
    
      public static MySingleton GetInstance()
      {    
        if (Instance == null)
        {
          lock(initLock)
          {
            if (Instance == null)
            {
              Instance = new MySingleton();
            }
          }
        }    
        return Instance;
      }
    }
