    var container = new Container();
    var schedulerFactory = new StdSchedulerFactory();
    container.RegisterSingle<IJobFactory>(
		new SimpleInjectorJobFactory(container, applicationAssemblies));
    container.RegisterSingle<ILoadServiceScheduler, TimerScheduler>();
    container.RegisterSingle<ISchedulerFactory>(schedulerFactory);
    container.Register<IScheduler>(() => schedulerFactory.GetScheduler());
    
    // Optional: register some decorators
    container.RegisterDecorator(typeof(IJob), typeof(LoggingJobDecorator));
    container.Verify();
