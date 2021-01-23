    var container = new Container();
    
    container.Options.ScopedLifestyle = new AsyncScopedLifestyle();
    var schedulerFactory = new StdSchedulerFactory();
    container.RegisterInstance<IJobFactory>(
        new SimpleInjectorJobFactory(container, applicationAssemblies));
    container.RegisterSingleton<ILoadServiceScheduler, TimerScheduler>();
    container.RegisterInstance<ISchedulerFactory>(schedulerFactory);
    container.Register<IScheduler>(() => schedulerFactory.GetScheduler());
    
    // Optional: register some decorators
    container.RegisterDecorator(typeof(IJob), typeof(LoggingJobDecorator));
    container.Verify();
