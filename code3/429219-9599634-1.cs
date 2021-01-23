    // Create container and register types using a name for each one
    IUnityContainer myContainer = new UnityContainer();
    myContainer.RegisterType<IMyProcessor, MyProcessorA>(); //default
    myContainer.RegisterType<IMyProcessor, MyProcessorB>("MyProcessorB");
    myContainer.RegisterType<IMyProcessor, MyProcessorC>("MyProcessorC");
    
    // Retrieve a list of non-default types registered for IMyProcessor
    // List will only contain the types MyProcessorB and MyProcessorC
    IEnumerable<IMyProcessor> serviceList = myContainer.ResolveAll<IMyProcessor>();
    //usage
    var library = new  MyProcessorLibrary(serviceList);
    library.ProcessAll();
