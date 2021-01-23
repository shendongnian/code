    public sealed class Plugin
    {
        private static readonly Plugin _instance;
        private static int _syncRoot;
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
                if (Interlocked.CompareExchance(ref _syncroot, 1, 0) == 0)
                {
                    _instance = new Plugin();
                }
                return _instance;
            }
        }
    }
