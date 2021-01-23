    class Log4NetLogger : ILogger
    {
        public Log4NetLogger(...)
        {
            if (!m_Configured){
                string configFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"MyApplication\Logging\Log4Net.config");
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));
                m_Configured = true;
            }
            ...
        }
        ...
    }
