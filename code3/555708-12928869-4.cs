    public sealed class Plugin
    {
        private static readonly Plugin _instance;
        private static int _initializationStarted;
        private static int _initializationEnded;
        private Dictionary<int, string> myMap;
    
        private Plugin()
        {
            myMap = MapInit(GetMainModuleName());
        }
    
        static Plugin()
        { }
    
        public static Plugin Instance
        {
            get
            {
                if (Interlocked.CompareExchance(ref _initializationStarted, 1, 0) == 0)
                {
                    _instance = new Plugin();
                    _initializationEnded = 1;
                }
                while (_initializationEnded == 0)
                {
                    //Wait
                }
                return _instance;
            }
        }
    }
