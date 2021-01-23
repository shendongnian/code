    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Threading;
    using log4net;
    using log4net.Core;
    using log4net.Appender;
    using log4net.Repository.Hierarchy;
    using System.Reflection;
    using System.IO;
    using COIN.SDK.Diagnostics;
    
    namespace [Your Namespace]
    {
        public static class DiagnosticsManager
        {
            private static bool isConfigured = false;
            private static ILog iLog;
    
            public static void Configure()
            {
                if (isConfigured)
                    return;
                
                var loggerName = typeof(DiagnosticsManager).FullName;
    
                var logger = (log4net.Repository.Hierarchy.Logger)log4net.LogManager.GetRepository().GetLogger(loggerName);
                var ilogger = log4net.LogManager.GetRepository().GetLogger(loggerName);
    
                //Add the default log appender if none exist
                if(logger.Appenders.Count == 0)
                {
                    var directoryName = "[Your directory name here. e.c. 'C:\ProgramData\AppName\Logs']";
                    
                    //If the directory doesn't exist then create it
                    if(!Directory.Exists(directoryName))
                        Directory.CreateDirectory(directoryName);
    
                    var fileName = Path.Combine(directoryName, "[Your static file name here. e.c. 'AppName.log']");
    
                    //Create the rolling file appender
                    var appender = new log4net.Appender.RollingFileAppender();
                    appender.Name = "RollingFileAppender";
                    appender.File = fileName;
                    appender.StaticLogFileName = true;
                    appender.AppendToFile = false;
                    appender.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Size;
                    appender.MaxSizeRollBackups = 10;
                    appender.MaximumFileSize = "10MB";
                    appender.PreserveLogFileNameExtension = true;
    
                    //Configure the layout of the trace message write
                    var layout = new log4net.Layout.PatternLayout()
                    {
                        ConversionPattern = "%date{hh:mm:ss.fff} [%thread] %-5level - %message%newline"
                    };
                    appender.Layout = layout;
                    layout.ActivateOptions();
    
                    //Let log4net configure itself based on the values provided
                    appender.ActivateOptions();
                    log4net.Config.BasicConfigurator.Configure(appender);
                }
    
                iLog = LogManager.GetLogger(loggerName);
                isConfigured = true;
    
                Info("Logging Configured at " + DateTime.Now.ToString("g"));
            }
    
            public static event EventHandler<ExceptionLoggedEventArgs> ExceptionLogged;
    
            public static void Debug(object message) { Configure(); iLog.Debug(message); }
            public static void Debug(object message, Exception exception) { Configure(); iLog.Debug(message, exception); }
    
            public static void Error(object message) { Configure(); iLog.Error(message); }
            public static void Error(object message, Exception exception) { Configure(); iLog.Error(message, exception); }
    
            public static void Fatal(object message) { Configure(); iLog.Fatal(message); }
            public static void Fatal(object message, Exception exception) { Configure(); iLog.Fatal(message, exception); }
    
            public static void Info(object message) { Configure(); iLog.Info(message); }
            public static void Info(object message, Exception exception) { Configure(); iLog.Info(message, exception); }
    
            public static void Warn(object message) { Configure(); iLog.Warn(message); }
            public static void Warn(object message, Exception exception) { Configure(); iLog.Warn(message, exception); }
    
        }
    
    }
