    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    string fileName = ((RollingFileAppender)log.Logger.Repository.GetCurrentLoggers()
        .Where(e => e.Name == "Your namespace.class").ToList()[0]
        .Repository.GetAppenders()
        .Where(e => e.Name == "MyAppender").ToList()[0]).File.ToString();
