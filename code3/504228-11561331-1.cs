    public static LastAccessConfigurationSection Config { get; internal set; }
    
        public static void Initialize() {
            Config = ConfigurationManager.GetSection("LastAccess") as LastAccessConfigurationSection;
        }
