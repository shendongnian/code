    public static Logger SetIfNeededAndGetLogger(string serviceName, string methodName)
    {
        Logger logger = null;
        try
        {
            if (!string.IsNullOrWhiteSpace(serviceName) && !string.IsNullOrWhiteSpace(methodName))
            {
                ILog log = null;
                var traceSourceName = string.Format("{0}{1}", serviceName, methodName);
                if (!string.IsNullOrWhiteSpace(traceSourceName))
                {
                    logger = LogSources.FirstOrDefault(x => x.ServiceLogType == traceSourceName);
                    if (logger == null)
                    {
                        log = LogManager.GetLogger(traceSourceName);
                        //logger = new Logger(log, IHEService.MediLogClientGuid, traceSourceName, methodName);
                        logger = new Logger(log, System.Guid.NewGuid(), traceSourceName, methodName);
                        SetLoggingSource(logger);
                    }
                }
            }
        }
        catch (Exception)
        {
            //silent faiure
        }
        return logger;
    }
    private static void SetLoggingSource(Logger value)
    {
        LogSources.Add(value);
    }
