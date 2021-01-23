    var container = new Container();
    // Always register your root types explicitly.
    container.RegisterQuartzJobs(jobsAssembly);
    var schedulerFactory = new StdSchedulerFactory();
    container.RegisterSingle<IJobFactory>(new SimpleInjectorJobFactory(container));
    container.RegisterSingle<ILoadServiceScheduler, TimerScheduler>();
    container.RegisterSingle<ISchedulerFactory>(schedulerFactory);
    container.Register<IScheduler>(() => schedulerFactory.GetScheduler());
    
    // Optional: register some decorators
    container.RegisterDecorator(typeof(IJob), typeof(LoggingJobDecorator));
    container.Verify();
