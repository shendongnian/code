    IUnityContainer container = new UnityContainer();
    // Assume we have a logger we are injecting
    container.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());
    // Register the Dependency Properties for the Page 
    // Property names on MyPage are "Logger" and "MyProperty2"
    container.RegisterType<MyPage>(new InjectionProperty("Logger"),
        new InjectionProperty("MyProperty2"));
    // Perform Property Injection.  
    // Logger will be injected from the existing container registration.  
    // For the other property set an override to inject the value we need
    // since it's not registered in the container.
    container.BuildUp<MyPage>(myPage, 
        new PropertyOverride("MyProperty2", "property value"));
