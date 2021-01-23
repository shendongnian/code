    public sealed class Plugin
    {
        private static readonly Plugin _instance;
        private static int _initializing;
        private static ManualReserEvent _done;
        private Dictionary<int, string> myMap;
    
        private Plugin()
        {
            myMap = MapInit(GetMainModuleName());
        }
    
        static Plugin()
        {
            _done = new ManualResetEvent(false);
        }
    
        public static Plugin Instance
        {
            get
            {
                if (Interlocked.CompareExchance(ref _initializing, 1, 0) == 0)
                {
                    _instance = new Plugin();
                    _done.Set();
                }
                else
                {
                    _done.WaitOne();
                }
                return _instance;
            }
        }
    }
