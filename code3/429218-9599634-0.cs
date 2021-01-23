    // Create container and register types using a name for each one
    IUnityContainer myContainer = new UnityContainer();
    myContainer.RegisterType<IMyService, DefaultService>();
    myContainer.RegisterType<IMyService, DataService>("Data");
    myContainer.RegisterType<IMyService, LoggingService>("Logging");
    
    // Retrieve a list of non-default types registered for IMyService
    // List will only contain the types DataService and LoggingService
    IEnumerable<IMyService> serviceList = myContainer.ResolveAll<IMyService>();
