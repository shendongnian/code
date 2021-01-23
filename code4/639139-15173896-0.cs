    public class OutOfHoneyException : Exception
    {
        public OutOfHoneyException()
            : base()
        {
        }
        public OutOfHoneyException(string message)
            : base(message)
        {
        }
        public OutOfHoneyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public OutOfHoneyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
