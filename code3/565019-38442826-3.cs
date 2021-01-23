     public static class SqlRetryErrorCodes
    {
        public const int TimeoutExpired = -2;
        public const int Deadlock = 1205;
        public const int CouldNotOpenConnection = 53;
        public const int TransportFail = 121;
    }
    public class MyCustomExecutionStrategy : DbExecutionStrategy
    {
        public MyCustomExecutionStrategy(int maxRetryCount, TimeSpan maxDelay) : base(maxRetryCount, maxDelay) { }
         private readonly List<int> _errorCodesToRetry = new List<int>
        {
            SqlRetryErrorCodes.Deadlock,
            SqlRetryErrorCodes.TimeoutExpired,
            SqlRetryErrorCodes.CouldNotOpenConnection,
            SqlRetryErrorCodes.TransportFail
        };
        protected override bool ShouldRetryOn(Exception exception)
        {
            var sqlException = exception as SqlException;
            if (sqlException != null)
            {
                foreach (SqlError err in sqlException.Errors)
                {
                    // Enumerate through all errors found in the exception.
                    if (_errorCodesToRetry.Contains(err.Number))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
