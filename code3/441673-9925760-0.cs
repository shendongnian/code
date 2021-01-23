    public class YourCustomException : Exception
    {
        public YourCustomException(Exception inner, string message)
        : base(inner, message)
        {
        }
    
    }
