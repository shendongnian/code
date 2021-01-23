    IUnityContainer container = new UnityContainer();
    // Assume we have a logger we are injecting
    container.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());
    // Register the Dependency Properties for the Page 'MyPage'.
    // Property names on MyPage are "Logger"
    container.RegisterType<MyPage>(new InjectionProperty("Logger"));
    // ...later
    IHttpHandler currentHandler = HttpContext.Current.Handler;
    // Perform Property Injection.  
    // Logger will be injected from the existing container registration.  
    container.BuildUp(currentHandler.GetType(), currentHandler);
