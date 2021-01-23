    var container = new Container();
    container.RegisterSingle<ILogger>(new Logger());
    // SqlUserRepository depends on ILogger
    container.Register<IUserRepository, SqlUserRepository>();
    // HomeController depends on IUserRepository
    // Concrete instances don't need to be resolved
    container.GetInstance(typeof(HomeController));
