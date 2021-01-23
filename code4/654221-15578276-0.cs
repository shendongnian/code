    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)]
    public class AppInitialized : System.Attribute
    {
        private MethodInfo _mInfo;
        public AppInitialized(Type t, String method)
        {
            _mInfo = t.GetMethod(method, BindingFlags.Static | BindingFlags.Public);
        }
        public void Initialize()
        {
            if (_mInfo != null)
                _mInfo.Invoke(null, null);
        }
    }
    [AppInitialized(typeof(InitializeMe), "Initialize")]
    public class InitializeMe
    {
        public static void Initialize()
        {
            Console.WriteLine("InitializeMe initialized");
        }
    }
