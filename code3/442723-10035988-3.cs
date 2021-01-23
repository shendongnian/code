        public static class DeadlockRetryHelper
        {
            private const int MaxRetries = 4;
            private const int SqlDeadlock = 1205;
            public static void Execute(Action action, int maxRetries = MaxRetries)
            {
                if (HasAmbientTransaction())
                {
                    // Deadlock blows out containing transaction
                    // so no point retrying if already in tx.
                    action();
                }
                int retries = 0;
                while (retries < maxRetries)
                {
                    try
                    {
                        action();
                        return;
                    }
                    catch (Exception e)
                    {
                        if (IsSqlDeadlock(e))
                        {
                            retries++;
                            // Delay subsequent retries - not sure if this helps or not
                            Thread.Sleep(100 * retries);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                action();
            }
            private static bool HasAmbientTransaction()
            {
                return Transaction.Current != null;
            }
            private static bool IsSqlDeadlock(Exception exception)
            {
                if (exception == null)
                {
                    return false;
                }
                var sqlException = exception as SqlException;
                if (sqlException != null && sqlException.Number == SqlDeadlock)
                {
                    return true;
                }
                if (exception.InnerException != null)
                {
                    return IsSqlDeadlock(exception.InnerException);
                }
                return false;
            }
        }
