    public static Logger Logger(this object obj) {
        Logger logger;
        Type type = obj.GetType();
        // s_loggers is static Dictionary<Type, Logger>
        if (!s_loggers.TryGetValue(type, out logger)) { // not in cache
            logger = LogManager.GetLogger(object.GetType());
            s_loggers[type] = logger;  // cache it
        }
        return logger;
    }
