    public static class LoggerFactory
    {
        public static ILogger GetLogger(Ninject.Activation.IContext context)
        {
            return GetLogger(context.Request.Target == null ? typeof(ILogger) : context.Request.Target.Member.DeclaringType);
        }
        private static readonly Dictionary<Type, ILogger> TypeToLoggerMap = new Dictionary<Type, ILogger>();
        private static ILogger GetLogger(Type type)
        {
            lock (TypeToLoggerMap)
            {
                if (TypeToLoggerMap.ContainsKey(type))
                    return TypeToLoggerMap[type];
                ILogger logger = new Logger(type);
                TypeToLoggerMap.Add(type, logger);
                return logger;
            }
        }
    }
