    var container = new Container();
    var scedularFactory = new StdSchedulerFactory();
    container.RegisterSingle<IJobFactory, SimpleInjectorJobFactory>();
    container.RegisterSingle<ILoadServiceScheduler, TimerScheduler>();
    container.RegisterSingle<ISchedulerFactory>(scedularFactory);
    container.Register<IScheduler>(() => scedularFactory.GetScheduler());
    // Optional but advisable: register all job implementations.
    container.Register<JobImplementation>();
    // Optional but advisable: verify thy container (http://bit.ly/VKvrLS).
    container.Verify();
