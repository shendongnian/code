    public interface ILogger
    {
        void Log( LogEntry entry );
        void Log( Type type, LogEntry entry );
    }
    
