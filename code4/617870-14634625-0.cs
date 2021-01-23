            String cfgFileName = "IntercompanyConsoleApp.exe.config";
            ExeConfigurationFileMap cfgMap = new ExeConfigurationFileMap();
            cfgMap.ExeConfigFilename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + cfgFileName;
            Configuration cfg = ConfigurationManager.OpenMappedExeConfiguration(cfgMap, ConfigurationUserLevel.None);
            // IntercompanyService is the name of my service app, which is where the real app.config file resides -- hence the entries in the xml are based on this application.
            // Also, the scope of my settings entries is Application
            ClientSettingsSection section = (ClientSettingsSection)cfg.GetSection("applicationSettings/IntercompanyService.Properties.Settings"); 
            Console.WriteLine(section.Settings.Get("Server").Value.ValueXml.InnerText);
            Console.WriteLine(section.Settings.Get("Database").Value.ValueXml.InnerText);                        
