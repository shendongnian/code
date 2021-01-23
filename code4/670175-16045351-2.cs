    internal class InstallBootstrapper
    {
        public Container Build()
        {
            var container = new Container();
            container.Register<ServiceProcessInstaller, 
                                            HelloServiceProcessInstaller>();
            container.Register<ServiceInstaller, 
                                            GreetServiceInstaller>();
            container.Register<IServiceNameProvider, 
                                            ServiceNameProvider>();
            container.Verify();
            return container;
        }
    }
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
               
            var bootstrapper = new InstallBootstrapper();
            var container = bootstrapper.Build();
                            
            var processInstallers = 
                      container.GetInstance<ServiceProcessInstaller>();
            var serviceInstaller = 
                      container.GetInstance<ServiceInstaller>();
            Installers.Add(processInstallers);
            Installers.Add(serviceInstaller);           
        }
    }
