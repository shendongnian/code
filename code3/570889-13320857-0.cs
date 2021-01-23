    public class InitializationException : Exception
    {
        public InitializationException()
        {}
        
        public InitializationException(string msg)
            : base(msg)
        {}
    
        public InitializationException(string msg, Exception inner)
            : base(msg, inner)
        {}
    }
    
