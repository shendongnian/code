    public static class ConfigurationLoader
    {
        static ConfigurationLoader()
        {
            // Dependency1 = LoadFromConfiguration();
            // Dependency2 = LoadFromConfiguration();
        }
        public static int Dependency1 { get; private set; }
        public static string Dependency2 { get; private set; }
    }
