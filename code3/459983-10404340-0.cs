    public class RestartServiceException : Exception
    {
        public RestartServiceException(string message)
            : base(message)
        {
        }
        // You could also write other constructor, passing parameters or use internal logic
        // to process your error condition
    }
