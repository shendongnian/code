    // don't do that:
    class ExceptionWithPresetStackTrace : System.Exception
    {
        public ExceptionWithPresetStackTrace(string stackTrace)
        {
            this.stackTrace = stackTrace;
        }
        
        public override string StackTrace
        {
            get
            {
                return stackTrace;
            }
        }
        readonly string stackTrace;
    }
