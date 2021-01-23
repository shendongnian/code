    public class MyAppSettings
    {
        // Where to store your settings
        private DataTable _storage = null;
    
        public MyAppSettings()
        {
           string settingFile = Path.Combine(Environment.GetFolderPath
                                (Environment.SpecialFolder.CommonApplicationData), 
                                "MyAppName", "MyAppSettings.xml");
           _storage = new DataTable();
           _storage.ReadXml(settingFile);
        }
        public void Save()
        {
           string settingFile = Path.Combine(Environment.GetFolderPath
                                (Environment.SpecialFolder.CommonApplicationData), 
                                "MyAppName", "MyAppSettings.xml");
           _storage.WriteXml(settingFile);
        }
    
        public string GetValue(string settingName)
        {
            // Code to search the base table
        }
        public void SetValue(string settingName, string settingValue)
        {
            // Code to update/insert the base table
        }
    }
