    public class DalWrapperException : Exception
    {
        public DalWrapperException()
        { }
    
        public DalWrapperException(string message)
            : base(message)
        { }
    
        public DalWrapperException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
