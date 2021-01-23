      var instance = MySingleton.Instance;
      while (true)
      {
         /// check for whether singleton initialization complete or not
         if (MySingleton.Initialized)
         {
           break;
         }
      }
  
      public class MySingleton
            {
                private static MySingleton _instance;
                private static readonly object _locker = new object();
                public static bool Initialized { get; set; }
        
                private MySingleton()
                {
                    ThreadPool.QueueUserWorkItem(call => Init());
                }
        
                public static MySingleton Instance
                {
                    get
                    {
                        if (_instance == null)
                            _instance = new MySingleton();
        
                        return _instance;
                    }
                }
        
                private void Init()
                {
                    lock (_locker)
                    {
                        if (Initialized)
                            return;
                        // long running code here...         
                        for (int i = 0; i < 10000; i++)
                        {
        
                        }
                        Initialized = true;
                    }
                }
            }
