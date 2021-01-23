    var container = new Container();
    
    container.Options.ScopedLifestyle = new AsyncScopedLifestyle();
    var factory = new StdSchedulerFactory();
    IScheduler scheduler = await factory.GetScheduler();
    scheduler.JobFactory = new SimpleInjectorJobFactory(
        container, 
        Assembly.GetExecutingAssembly()); // assemblies that contain jobs
    
    // Optional: register some decorators
    container.RegisterDecorator(typeof(IJob), typeof(LoggingJobDecorator));
    container.Verify();
