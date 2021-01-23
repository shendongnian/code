    public class MySingleton
    {
        static private MySingleton singleton = null;
        private static readonly object padlock = new object();
    
        static public MySingleton Retrieve
        {
            get
            {
                lock (padlock)
                {
                    if (singleton == null) singleton = new MySingleton(); // Initialize as needed
                }
                return singleton;
            }
        }
    }
