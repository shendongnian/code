    public static class LogGateway
    {
        static LogGateway() 
        { 
            XmlConfigurator.Configure();  
        }
        public static ILog For( object LoggedObject )
        {
            if ( LoggedObject != null )
                return For( LoggedObject.GetType() );
            else
                return For( (string)null );
        }
        public static ILog For( Type ObjectType )
        {
            if ( ObjectType != null )
                return LogManager.GetLogger( ObjectType );
            else
                return LogManager.GetLogger( string.Empty );
        }
        public static ILog For( string LoggerName )
        {
            return LogManager.GetLogger( LoggerName );
        }
    } 
