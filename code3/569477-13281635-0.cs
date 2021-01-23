    MyContainer.Register<LoggingService>().As<ILoggingService>();
    MyContainer.Register<DataService>().As<IDataService>();
    MyContainer.Register<MessagingService>().As<IMessagingService>();
    MyContainer.Register<Repository>().As<IRepository>();
    MyContainer.Register<AppController>().As<IAppController>();
    
