    var container = new Container();
    
    container.Options.ScopedLifestyle = new AsyncScopedLifestyle();
    var schedulerFactory = new StdSchedulerFactory();
    container.RegisterSingle<IJobFactory>(
        new SimpleInjectorJobFactory(container, applicationAssemblies));
    container.RegisterSingle<ILoadServiceScheduler, TimerScheduler>();
    container.RegisterSingle<ISchedulerFactory>(schedulerFactory);
    container.Register<IScheduler>(() => schedulerFactory.GetScheduler());
    
    // Optional: register some decorators
    container.RegisterDecorator(typeof(IJob), typeof(LoggingJobDecorator));
    container.Verify();
