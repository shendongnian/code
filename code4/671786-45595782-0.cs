    public static class Statics
    {
        public static string CurrentBrowsePath { get; set; }
        public static void initialization()
        {
            ConfigurationManager.RefreshSection("appSettings");
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CurrentBrowsePath = ConfigurationManager.AppSettings["lastfolder"];
        }
    }
