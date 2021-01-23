    public class WebFaultException : Exception
    {
        public WebFaultException() { }
        public WebFaultException(string message) : base(message) { }
        public WebFaultException(string message, Exception innerException) : base(message, innerException) { }
        protected WebFaultException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    public class WebFaultException<T> : WebFaultException
    {
        public WebFaultException() { }
        public WebFaultException(string message) : base(message) { }
        public WebFaultException(string message, Exception innerException) : base(message, innerException) {  }
        protected WebFaultException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
    }
