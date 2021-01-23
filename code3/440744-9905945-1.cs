	/// <summary>
	/// Test for Log4Net
	/// </summary>
	public static void TestLog4Net()
	{
		// Configures log4net
		ConfigureLog4net();
		ILog log = LogManager.GetLogger("foo");
		log.Debug("This should not appear in a logfile!");
		ILog log2 = LogManager.GetLogger("NHibernate.SQL");
		log2.Debug("This should only appear in the NH logfile!");
		ILog log3 = LogManager.GetLogger("MyProgram");
		log3.Debug("This should appear in the main program logfile!");
	}
	/// <summary>
	/// Configures log4net
	/// </summary>
	public static void ConfigureLog4net()
	{
		Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
		// Remove any other appenders
		hierarchy.Root.RemoveAllAppenders();
		// define some basic settings for the root
		Logger rootLogger = hierarchy.Root;
		rootLogger.Level = Level.Debug;
		// declare a RollingFileAppender with 5MB per file and max. 10 files
		RollingFileAppender appenderNH = new RollingFileAppender();
		appenderNH.Name = "RollingLogFileAppenderNHibernate";
		appenderNH.AppendToFile = true;
		appenderNH.MaximumFileSize = "5MB";
		appenderNH.MaxSizeRollBackups = 10;
		appenderNH.RollingStyle = RollingFileAppender.RollingMode.Size;
		appenderNH.StaticLogFileName = true;
		appenderNH.LockingModel = new FileAppender.MinimalLock();
		appenderNH.File = "log-nhibernate.log";
		appenderNH.Layout = new PatternLayout("%date - %message%newline");
		// this activates the FileAppender (without it, nothing would be written)
		appenderNH.ActivateOptions();
		// This is required, so that we can access the Logger by using 
		// LogManager.GetLogger("NHibernate.SQL") and it can used by NHibernate
		Logger loggerNH = hierarchy.GetLogger("NHibernate.SQL") as Logger;
		loggerNH.Level = Level.Debug;
		loggerNH.AddAppender(appenderNH);
		// declare RollingFileAppender with 5MB per file and max. 10 files
		RollingFileAppender appenderMain = new RollingFileAppender();
		appenderMain.Name = "RollingLogFileAppenderMyProgram";
		appenderMain.AppendToFile = true;
		appenderMain.MaximumFileSize = "5MB";
		appenderMain.MaxSizeRollBackups = 10;
		appenderMain.RollingStyle = RollingFileAppender.RollingMode.Size;
		appenderMain.StaticLogFileName = true;
		appenderMain.LockingModel = new FileAppender.MinimalLock();
		appenderMain.File = "log-MyProgram.log";
		appenderMain.Layout = new PatternLayout(
			"%date [%thread] %-5level %logger [%ndc] - %message%newline");
		// this activates the FileAppender (without it, nothing would be written)
		appenderMain.ActivateOptions();
		// This is required, so that we can access the Logger by using 
		// LogManager.GetLogger("MyProgram") 
		Logger logger = hierarchy.GetLogger("MyProgram") as Logger;
		logger.Level = Level.Debug;
		logger.AddAppender(appenderMain);
		// this is required to tell log4net that we're done 
		// with the configuration, so the logging can start
		hierarchy.Configured = true;
	}
