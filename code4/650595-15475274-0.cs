    Assembly service = Assembly.GetAssembly(typeof(ProjectInstaller));
    string assemblyPath = service.Location;
    Configuration config = ConfigurationManager.OpenExeConfiguration(assemblyPath);
    KeyValueConfigurationCollection mySettings = config.AppSettings.Settings;
    processInstaller.Account = (ServiceAccount)Enum.Parse(typeof(ServiceAccount), mySettings["Account"].Value);
