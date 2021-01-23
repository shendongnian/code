    public class MySingleton
    {
        private static MySingleton _instance;
        private static ManualResetEvent _initEvent = new ManualResetEvent(false);
    
        static MySingleton() 
        {
            ThreadPool.QueueUserWorkItem(state => Init());
        }
    
        public static MySingleton Instance 
        {
            _initEvent.Wait();
            return _instance;
        }
        private static void Init()
        {
            _instance = new MySingleton();
            // long running code here...
            
            
            _initEvent.Set();
        }
    }
