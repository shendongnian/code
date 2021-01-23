    public class MySuperAwesomeException : Exception
    {
        public MySuperAwesomeException() : base() { }
        public MySuperAwesomeException(string message) : base(message) { }
        public MySuperAwesomeException(string message, Exception innerException)
            : base(message, innerException) { }
    }
