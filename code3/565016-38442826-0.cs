     public class SQLRetryErrorCodes
    {
        public static int TIMEOUT_EXPIRED = -2;
        public static int DEADLOCK = 1205;
        public static int COULD_NOT_OPEN_CONNECTION = 53;
        public static int TRANSPORT_FAIL = 121;
    }
    public class MyCustomExecutionStrategy : DbExecutionStrategy
    {
        public MyCustomExecutionStrategy(int maxRetryCount, TimeSpan maxDelay) : base(maxRetryCount, maxDelay) { }
        private readonly List<int> _errorCodesToRetry = new List<int>
        {
            SQLRetryErrorCodes.DEADLOCK,
            SQLRetryErrorCodes.TIMEOUT_EXPIRED,
            SQLRetryErrorCodes.COULD_NOT_OPEN_CONNECTION,
            SQLRetryErrorCodes.TRANSPORT_FAIL
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
