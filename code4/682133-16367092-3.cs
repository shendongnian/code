    public void Log( LogEntry entry )
    {
        this.Log( this.GetType(), entry );
    }
    
    public void Log( Type type, LogEntry entry)
    {
        NLogLogger.Log( type, new NLog.LogEventInfo( ... ) );
    }
    
