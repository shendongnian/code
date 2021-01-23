    public class ConfigSettingsDictionary
        {
            public Dictionary<String, String> ConfigSettings = new Dictionary<String, String>();
        }
        ConfigSettingsDictionary MyConfigurationSettings = new ConfigSettingsDictionary();
 
    private void SaveConfig()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YOUR_APP_NAME_PLUS_UNIQUE_VALUE.config"))
            {
                foreach (var pair in MyConfigurationSettings.ConfigSettings)
                {
                    sw.WriteLine(pair.Key + "=" + pair.Value);
                }
            }
        }
        private void LoadConfig()
        {
            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YOUR_APP_NAME_PLUS_UNIQUE_VALUE.config"))
            {
                var settingdata = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YOUR_APP_NAME_PLUS_UNIQUE_VALUE.config");
                for (var i = 0; i < settingdata.Length; i++)
                {
                    var setting = settingdata[i];
                    var sidx = setting.IndexOf("=");
                    if (sidx >= 0)
                    {
                        var skey = setting.Substring(0, sidx);
                        var svalue = setting.Substring(sidx + 1);
                        if (!MyConfigurationSettings.ConfigSettings.ContainsKey(skey))
                        {
                            MyConfigurationSettings.ConfigSettings.Add(skey, svalue);
                        }
                    }
                }
            }
          
        }
        private void UpdateConfig(Dictionary<String, String> keyvaluepairs)
        {
            
            foreach (var pair in keyvaluepairs)
            {
               if (!MyConfigurationSettings.ConfigSettings.ContainsKey(pair.Key))
               {
                   MyConfigurationSettings.ConfigSettings.Add(pair.Key, pair.Value);
               }
               else
               {
                   MyConfigurationSettings.ConfigSettings[pair.Key] = pair.Value;
               }
            }
         
         
        }
