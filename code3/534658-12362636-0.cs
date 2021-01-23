    [RunInstaller(true)]
    public class Installer : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;
    
        public Installer()
        {
            // Instantiate installers for process and services.
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();
    
            // The services run under the system account.
            processInstaller.Account = ServiceAccount.LocalSystem;
    
            // The services are started manually.
            serviceInstaller.StartType = ServiceStartMode.Manual;
    
            // ServiceName must equal those on ServiceBase derived classes.
            serviceInstaller.ServiceName = "Hello-World Service 1";
    
            // Add installers to collection. Order is not important.
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
