    public class RestartServiceException : Exception
    {
        public RestartServiceException(string message)
            : base(message)
        {
        }
        // You could also write other constructors with different parameters and use internal logic
        // to process your error message
    }
