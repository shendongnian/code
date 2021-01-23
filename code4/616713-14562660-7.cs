    var container = new Container();
    var scedulerFactory = new StdSchedulerFactory();
    container.RegisterSingle<IJobFactory, SimpleInjectorJobFactory>();
    container.RegisterSingle<ILoadServiceScheduler, TimerScheduler>();
    container.RegisterSingle<ISchedulerFactory>(scedulerFactory);
    container.Register<IScheduler>(() => scedulerFactory.GetScheduler());
    // Optional but advisable: register all job implementations.
    container.Register<JobImplementation>();
    // Optional but advisable: verify thy container (http://bit.ly/VKvrLS).
    container.Verify();
