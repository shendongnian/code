    [RunInstaller(true)]
    public class InstallMyService : Installer
    {
        public InstallMyService()
        {
            var svc = new ServiceInstaller();
    
            svc.ServiceName = "MyService";
            svc.Description = "This is a service";
            svc.DisplayName = "My Service";
            svc.StartType = ServiceStartMode.Automatic;
    
            var svcContext = new ServiceProcessInstaller();
            svcContext.Account = ServiceAccount.LocalSystem;
    
            Installers.Add(svc);
            Installers.Add(svcContext);
        }
    }
