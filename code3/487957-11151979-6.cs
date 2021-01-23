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
    // The parent contains information about the type in 
    // which ILogger is injected.
    container.RegisterWithContext<ILogger>(parent =>
    {
        // Retrieve a new LoggerImpl instance from the container 
        // to allow this type to be auto-wired.
        var logger = container.GetInstance<LoggerImpl>();
        // ImplementationType is null when ILogger is
        // requested directly (using GetInstance<ILogger>())
        // since it will have no parent in that case.
        if (parent.ImplementationType != null)
        {
            // Set the LogName with the name of the class 
            // it is injected into.
            logger.LogName = parent.ImplementationType.Name;
        }
        return logger;
    });
    // Register the LoggerImpl as transient. This line is
    // in fact redundant in Simple Injector, but it is important
    // to not accidentally register this type with another
    // lifestyle, since the previous registration depends on it
    // to be transient.
    container.Register<LoggerImpl>();
