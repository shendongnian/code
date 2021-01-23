    internal static class Translation
    {
        public static ResourceLoader ResourceLoader { get; private set; }
        static Translation()
        {
            ResourceLoader = new ResourceLoader();
        }
        public static string MyFirstString
        {
            get { return ResourceLoader.GetString("MyFirstString/Text"); }
        }
    }
