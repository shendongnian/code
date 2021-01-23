    // Define a lifestyle once based on the deployment.
    var scopedLifestyle =  
        HostingEnvironment.ApplicationHost != null ?
        new WebRequestLifestyle() :
        new LifetimeScopeLifestyle();
    // And use it for registering the unit of work
    // (no extra interfaces needed anymore).
    container.Register<IUnitOfWork, UnitOfWork>(scopedLifestyle);
    // The lifestyle can be reused for many registrations if
    // needed.
    container.RegisterManyForOpenGeneric(
        typeof(ISubscriber<>),
        typeof(ISubscriber<>).Assembly,
        scopedLifestyle);
