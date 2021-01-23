    public class SettingsFromConfiguration : ISettings 
    {
        public int SettingA 
        {
            get 
            {
                string setting = ConfigurationManager.AppSettings["settingA"];
                int value = 0;
                int.TryParse(setting, out value);
                return value;
            }
        }
      
        public string SettingB 
        {
            get { return ConfigurationManager.AppSettings["settingB"];}
        }
    }
