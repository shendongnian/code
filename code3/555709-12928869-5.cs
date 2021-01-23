    public sealed class Plugin
    {
        private static readonly Plugin _instance;
        private /*readonly?*/ Dictionary<int, string> myMap;
    
        private Plugin()
        {
            myMap = MapInit(GetMainModuleName());
        }
    
        static Plugin()
        {
            _instance = new Plugin();
        }
    
        public static Plugin Instance
        {
            get
            {
                return _instance;
            }
        }
    }
