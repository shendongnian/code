    // Create container and register types using a name for each one
    IUnityContainer myContainer = new UnityContainer();
    myContainer.RegisterType<IMyProcessor, MyProcessor1>();
    myContainer.RegisterType<IMyProcessor, MyProcessor2>("number2");
    // Retrieve a list of non-default types registered for IMyService
    IEnumerable<IMyProcessor> processors = myContainer.ResolveAll<IMyService>();
