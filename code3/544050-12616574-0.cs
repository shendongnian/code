    public static class Conf {
        public static string ServerURLOverride { get; set; }
    
        public static string ServerUrl {
            get { return ServerURLOverride ?? ConfigurationManager.AppSettings["ServerURL"]; }
        }
    }
