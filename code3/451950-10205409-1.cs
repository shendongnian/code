    public abstract class Logger
    {
        static Logger()
        {
            Current = new DefaultLogger();
        }
        public static Logger Current { get; set; }
        
        // your Logger members
        public abstract void Log();
    }
