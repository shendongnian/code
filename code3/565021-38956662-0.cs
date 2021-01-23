    public static class RetryHelper
    {
       
        public static void DeadlockRetryHelper(Action method, int maxRetries = 3)
        {
            var retryCount = 0;
            while (retryCount < maxRetries)
            {
                try
                {
                    method();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Number == 1205)// Deadlock           
                    {
                        // Wait between 1 and 5 seconds
                        Thread.Sleep(new Random().Next(1000, 5000));
                        retryCount++;
                        if (retryCount >= maxRetries)
                            throw;
                    }
                    else
                        throw;
                }
            }
        }
    }
