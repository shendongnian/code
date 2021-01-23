    public static class Definitions
    {
    #if PRODUCTION
        public const string CURRENT_NAMESPACE = "MyProduction Namespace";
    #else
        public const string CURRENT_NAMESPACE = "MyTest Namespace";
    #endif
    };
