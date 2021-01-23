        public static string GetConnectionString()
        {
            var conStr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseEntities"].ConnectionString;
            return conStr.Replace("%APPDATA%",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        }
