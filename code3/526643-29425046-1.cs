    using System.Configuration;
    
    string lastused = "";
    Configuration refconfig = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
    
    // load last used directory value and check to see if setting has been written yet, or null error...
                if (refconfig.AppSettings.Settings["folderBrowserDialog1_last_used"] != null)
                {
                    lastused = refconfig.AppSettings.Settings["folderBrowserDialog1_last_used"].Value;
                }
                if (lastused != "")
                {
                    folderBrowserDialog1.SelectedPath = lastused;
                }
    // else use my docs
                else
                {
                    string defaultFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    folderBrowserDialog1.SelectedPath = defaultFolderPath;
                }
    
                try
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
    
                        if (folderBrowserDialog1.SelectedPath != "")
                        {
    
                      
    
                            textBoxFolderPath.Text = folderBrowserDialog1.SelectedPath;
    
    //  save path
                            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                            config.AppSettings.Settings.Remove("folderBrowserDialog1_last_used");
                            config.AppSettings.Settings.Add("folderBrowserDialog1_last_used", folderBrowserDialog1.SelectedPath);
                            config.Save(ConfigurationSaveMode.Minimal);
                        }
