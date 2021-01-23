    var container = new Container();
    container.RegisterSingle<IJobFactory, SimpleInjectorJobFactory>();
    container.RegisterSingle<ILoadServiceScheduler, TimerScheduler>();
    container.RegisterSingle<ISchedulerFactory, StdSchedulerFactory>();
    container.Register<IScheduler>(() =>
        container.GetInstance<ISchedulerFactory>().GetScheduler());
    // Optional but advisable: register all job implementations.
    container.Register<JobImplementation>();
    // Optional but advisable: verify thy container.
    container.Verify();
