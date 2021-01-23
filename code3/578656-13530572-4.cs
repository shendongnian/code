     internal class WebWindsorInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
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
    
                container.Register(Classes
                    .FromAssemblyContaining<Api.CategoriesController>()
                    .BasedOn<IHttpController>()
                    .If(t => t.Name.EndsWith("Controller"))
                    .LifestylePerWebRequest());
            }
        }
