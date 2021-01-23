    public class ControllersInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Register(FindControllers().Configure(c => c.LifestyleTransient()));
    
                container.Register(Component
                    .For<RepositoryFactories>()
                    .ImplementedBy<RepositoryFactories>()
                    .LifestyleSingleton());
    
                container.Register(Component
                    .For<IRepositoryProvider>()
                    .ImplementedBy<RepositoryProvider>()
                    .LifestylePerWebRequest());
    
                container.Register(Component
                    .For<IProjUow>()
                    .ImplementedBy<ProjUow>()
                    .LifestylePerWebRequest());
            }
            
            private static BasedOnDescriptor FindControllers()
            {
    
                return AllTypes.FromThisAssembly()
                    .BasedOn<IController>()
                    .If(t => t.Name.EndsWith("Controller"));
            }
        }
