    // Release the lock on the log4net log files
    var appenders = log4net.LogManager.GetRepository().GetAppenders();
    foreach (var appender in appenders)
    {
        var rollingFileAppender = appender as log4net.Appender.RollingFileAppender;
        if (rollingFileAppender != null)
        {
            rollingFileAppender.ImmediateFlush = true;
            rollingFileAppender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
            rollingFileAppender.ActivateOptions();
        }
    }
