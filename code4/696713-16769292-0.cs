    process = new ServiceProcessInstaller();
    process.Account = ServiceAccount.LocalSystem;
    service = new ServiceInstaller();
    
    var path = Assembly.GetExecutingAssembly().Location;
    var config = ConfigurationManager.OpenExeConfiguration(path);
    service.ServiceName = config.AppSettings.Settings["ServiceName"];
    Installers.Add(process);
    Installers.Add(service);
