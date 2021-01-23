    container.Register(Component.For<IHttpControllerFactory>().ImplementedBy<WindsorHttpControllerFactory>().LifeStyle.Singleton);
    container.Register(Component.For<System.Web.Http.Common.ILogger>().ImplementedBy<MyLogger>().LifeStyle.Singleton);
    container.Register(Component.For<IFormatterSelector>().ImplementedBy<FormatterSelector>().LifeStyle.Singleton);
    container.Register(Component.For<IHttpControllerActivator>().ImplementedBy<DefaultHttpControllerActivator>().LifeStyle.Transient);
    container.Register(Component.For<IHttpActionSelector>().ImplementedBy<ApiControllerActionSelector>().LifeStyle.Transient);
    container.Register(Component.For<IActionValueBinder>().ImplementedBy<DefaultActionValueBinder>().LifeStyle.Transient);
    container.Register(Component.For<IHttpActionInvoker>().ImplementedBy<ApiControllerActionInvoker>().LifeStyle.Transient);
    container.Register(Component.For<System.Web.Http.Metadata.ModelMetadataProvider>().ImplementedBy<System.Web.Http.Metadata.Providers.CachedDataAnnotationsModelMetadataProvider>().LifeStyle.Transient);
    container.Register(Component.For<HttpConfiguration>().Instance(configuration));
    //Register all api controllers
    container.Register(AllTypes.FromAssembly(assemblyToRegister)
                                .BasedOn<IHttpController>()
                                .Configure(registration => registration.Named(registration.ServiceType.Name.ToLower().Replace("controller", "")).LifeStyle.Transient));
    //Register WindsorHttpControllerFactory with Service resolver
    GlobalConfiguration.Configuration.ServiceResolver.SetService(typeof(IHttpControllerFactory), container.Resolve<IHttpControllerFactory>());
