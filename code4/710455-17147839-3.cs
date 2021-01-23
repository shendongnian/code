    private void btnSave(object sender, RoutedEventArgs e)
            {
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string configFile = System.IO.Path.Combine(appPath, "MyApp.exe.config");
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = configFile;
                System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
    
                config.AppSettings.Settings["ExportPath"].Value = txtExport.Text;
                config.AppSettings.Settings["CompanyName"].Value = txtComapny.Text;
                config.AppSettings.Settings["mail"].Value = txtEmail.Text;
                config.AppSettings.Settings["phone"].Value = txtPhone.Text;
                config.AppSettings.Settings["Print"].Value = print;
                config.AppSettings.Settings["EnforcePassw"].Value = password;
                config.AppSettings.Settings["ExpDate"].Value = color;
                config.Save(); 
                
            }
