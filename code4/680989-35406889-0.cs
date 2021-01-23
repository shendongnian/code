    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;
    using log4net.Repository;
    using log4net.Repository.Hierarchy;
    using System;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        [AttributeUsage(AttributeTargets.Assembly)]
        public class MyConfiguratorAttribute : ConfiguratorAttribute
        {
            public MyConfiguratorAttribute()
                : base(0)
            {
            }
            public override void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository)
            {
                var hierarchy = (Hierarchy)targetRepository;
                var patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
                patternLayout.ActivateOptions();
                var roller = new RollingFileAppender();
                roller.AppendToFile = false;
                roller.File = @"Logs\EventLog.txt";
                roller.Layout = patternLayout;
                roller.MaxSizeRollBackups = 5;
                roller.MaximumFileSize = "1GB";
                roller.RollingStyle = RollingFileAppender.RollingMode.Size;
                roller.StaticLogFileName = true;
                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);
                hierarchy.Root.Level = Level.Info;
                hierarchy.Configured = true;
            }
        }
    }
