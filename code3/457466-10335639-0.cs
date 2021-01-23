    ILoggerRepository repository = log4net.LogManager.GetRepository();
    var appender = repository.GetAppenders()
        .Where(a => a.Name == "dev")
        .Single();
    appender.Close();
