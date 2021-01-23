    internal class InstallBootstrapper
    {
        public Container Build()
        {
            var container = new Container();
            container.RegisterLifetimeScope<ServiceProcessInstaller, 
                                            HelloServiceProcessInstaller>();
            container.RegisterLifetimeScope<ServiceInstaller, 
                                            GreetServiceInstaller>();
            container.RegisterLifetimeScope<IServiceNameProvider, 
                                            ServiceNameProvider>();
            container.Verify();
            return container;
        }
    }
