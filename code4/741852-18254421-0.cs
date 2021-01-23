    class SQM
    {
    
        static Lazy<SQM> _Instance = new Lazy<SQM>( CreateInstance );
        private static SQM CreateInstance()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler( Cleanup );
            return new SQM();
        }
        private static Cleanup()
        {
            ...
        }
    
    }
