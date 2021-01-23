    private static void ExecuteWithDeadlockRetry(int maxAttempts, bool useTransaction, Action action)
    {
        int tryCount = 0;
        string errorMessage;
        // If use transaction is true and there is an existing ambient transaction (means we're in a transaction already)
        // then it will not do any good to attempt any retries, so set max retry limit to 1.
        if (useTransaction && Transaction.Current != null) { maxAttempts = 1; }
        do
        {
            try
            {
                // increment the try count...
                tryCount++;
                if (useTransaction)
                {
                    // execute the action inside a transaction...
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        action();
                        transactionScope.Complete();
                    }
                }
                else
                    action();
                // If here, execution was successful, so we can return...
                return;
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == (int)SqlExceptionNumber.Deadlock && tryCount < maxAttempts)
                {
                    // Log error here
                }
                else
                {
                    throw;
                }
            }
        } while (tryCount <= maxAttempts);
    }
