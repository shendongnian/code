    private void PerformTransactionalOperation()
    {
        Log.Write("Starting operation.");        
        try
        {
            using (var scope = CreateTransactionScope())
            {
                if (PerformTransactionalOperationCore())
                {
                    Log.Write("Committing...");
                    scope.Complete();
                    Log.Write("Committed");
                }
                else
                {
                    Log.Write("Operation aborted.");
                }
            }
        }
        catch (Exception exception)
        {
            Log.Write("Operation failed: " + exception.Message);
            throw;
        }
    }
    private bool PerformTransactionalOperationCore()
    {
        // Perform operations and return status...
    }
