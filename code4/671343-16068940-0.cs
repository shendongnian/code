    public class Singleton
    {
        private static Singleton _instance;
        private static object _instanceLock = new object();
    
        private Singleton()
        {
            //do stuff
        }
    
        public static Singleton Get()
        {
            if (_instance == null)
            {
                lock(_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    
        public static void Clear()
        {
            if (_instance != null)
            {
                lock(_instanceLock)
                {
                    if (_instance != null)
                    {
                        _instance = null;
                    }
                }
            }
        }
    }
