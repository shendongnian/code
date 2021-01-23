    public class Logger
    {
        private Logger(...) { ... }
    
        static Logger { /* initialize Errors, Warnings */ }
    
        public static Logger Errors { get; private set; }
        public static Logger Warnings { get; private set; }
        public void Write(string message) { ... }
    }
