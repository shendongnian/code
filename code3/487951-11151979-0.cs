    public interface ILogger
    {
        void LogMessage(string message, LogLevel level,
            ILoggableCompany company = null);
        // No LogName property here. Keep it clean.
    }
    public class LoggerImpl : ILogger
    {
        public void LogMessage(string message, 
            LogLevel level, ILoggableCompany company)
        {
           // implementation
        }
    
        // Property only part of the implementation.
        public string LogName {get; set; }
    }
    // The context contains information about the type in 
    // which ILogger is injected.
    container.RegisterWithContext<ILogger>(context =>
    {
        // Retrieve the LoggerImpl from the container to 
        // allow this type to be auto-wired.
        var logger = container.GetInstance<LoggerImpl>();
        // ImplementationType is null when ILogger is
        // requested, for instance using
        // directlycontainer.GetInstance<ILogger>()).
        if (context.ImplementationType != null)
        {
            // Set the LogName with the name of the class 
            // it is injected into.
            logger.LogName = context.ImplementationType.Name;
        }
        return logger;
    });
