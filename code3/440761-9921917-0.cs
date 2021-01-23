        public class CustomSqlAzureTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
        {
            private readonly SqlAzureTransientErrorDetectionStrategy _normalStrategy =
                new SqlAzureTransientErrorDetectionStrategy();
    
            public bool IsTransient(Exception ex)
            {
                if (_normalStrategy.IsTransient(ex))
                    return true;
    
                //do our custom logic
                if (ex is SqlException)
                {
                    var sqEx = ex as SqlException;
                    if (sqEx.Message.Contains("The timeout period elapsed prior to completion of the operation or the server is not responding") ||
                        sqEx.Message.Contains("An existing connection was forcibly closed by the remote host") ||
                        sqEx.Message.Contains("The service has encountered an error processing your request. Please try again") ||
                        sqEx.Message.Contains("Timeout expired") ||
                        sqEx.Message.Contains("was deadlocked on lock resources with another process and has been chosen as the deadlock victim") ||
                        sqEx.Message.Contains("A transport-level error has occurred when receiving results from the server"))
                    {                        
                        return true;
                    }
                }
    
                return false;
            }
        }
