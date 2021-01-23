    private void btnSave(object sender, RoutedEventArgs e)
            {
                //returns path of folder where your application is
                string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //combines path of folder and file
                string configFile = System.IO.Path.Combine(appPath, "MyApp.exe.config");
                //Defines the configuration file mapping for an .exe application
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
