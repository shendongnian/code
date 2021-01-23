    public static class Config
    {
        private static readonly _param1;
        static Config()
        {
            _param1 = ConfigurationManager.AppSettings["Param1"] ?? "Your default value";
        }
	
        public static string Param1
        {
            get { return _param1; }
        }
    }
