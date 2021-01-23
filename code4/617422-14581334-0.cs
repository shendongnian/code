    public static LoggingService
    {
        private static ILoggingService _current;
        public static ILoggingService Current
        {
            get 
            {
                if(_current == null) { _current = Container.Current.Resolve<ILoggingService>(); }
                return _current;  
            }
        }
    }
