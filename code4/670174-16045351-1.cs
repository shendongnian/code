    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
               
            var bootstrapper = new InstallBootstrapper();
            var container = bootstrapper.Build();
                            
            using(container.BeginLifetimeScope())
            {
                var processInstallers = 
                      container.GetInstance<ServiceProcessInstaller>();
                var serviceInstaller = 
                      container.GetInstance<ServiceInstaller>();
                Installers.Add(processInstallers);
                Installers.Add(serviceInstaller);
            }
        }
    }
