    public class AppSettings
    {
        private static readonly XmlSerializer Serializer 
                      = new XmlSerializer(typeof(AppSettings));
        public string CompanyName { get; set; }
        public string CompanyPhone { set; get; }
        private static string GetSettingsFile()
        {
            return null;
        }
        public static void SaveSettings(AppSettings settings)
        {
            using (var stream = File.OpenWrite(GetSettingsFile()))
                Serializer.Serialize(stream, settings);
        }
        internal static AppSettings LoadSettings()
        {
            if (!File.Exists(GetSettingsFile()))
                return null;
            object appsetting = null;
            using (var stream = File.OpenRead(GetSettingsFile()))
                appsetting = Serializer.Deserialize(stream);
            return appsetting as AppSettings;
        }
    }
