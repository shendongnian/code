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
     // then I use it like this:
    string lastused = "";
          
            if (MyConfigurationSettings.ConfigSettings.ContainsKey("openFileDialog2_last_used"))
            {
              MyConfigurationSettings.ConfigSettings.TryGetValue("openFileDialog2_last_used", out lastused);
            }
            if (lastused != "")
            {
                openFileDialog2.InitialDirectory = lastused;
            }
            else
            {
                openFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            string filestring = "";
            if (template_filename == "")
            {
                try
                {
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        filestring = openFileDialog2.FileName;
                        String chosenPath = Path.GetDirectoryName(openFileDialog2.FileName);
                        Dictionary<String, String> settings_to_save = new Dictionary<String, String>();
                        settings_to_save.Add("openFileDialog2_last_used", chosenPath);
                        settings_to_save.Add("openFileDialog2_last_used_template_file", filestring);
                        UpdateConfig(settings_to_save);
    }
             else return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error.", "Invalid File", MessageBoxButtons.OK);
                    return;
                }
    private void YOURFORMNAME_Load(object sender, EventArgs e)
        {
    // Load configuration file          
    LoadConfig();
        }
     private void YOURFORMNAME_FormClosing(object sender, FormClosingEventArgs e)
        {
    // Save configuration file
            SaveConfig();
        }
