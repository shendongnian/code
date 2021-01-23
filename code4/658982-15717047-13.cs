    var container = new Container();
    container.RegisterSingleton<ILogger>(new FileLogger("c:\\logs\\log.txt"));
    // SqlUserRepository depends on ILogger
    container.Register<IUserRepository, SqlUserRepository>();
    // HomeController depends on IUserRepository
    // Concrete instances don't need to be resolved
    container.GetInstance(typeof(HomeController));
