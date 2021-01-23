    public T DeadlockRetryHelper<T>(Func<T> repositoryMethod, int maxRetries)
    {
      int retryCount = 0;
      while (retryCount < maxRetries)
      {
        try
        {
          return repositoryMethod();
        }
        catch (SqlException e) // This example is for SQL Server, change the exception type/logic if you're using another DBMS
        {
          if (e.Number == 1205)  // SQL Server error code for deadlock
          {
            retryCount++;
          }
          else
          {
            throw;  // Not a deadlock so throw the exception
          }
          // Add some code to do whatever you want with the exception once you've exceeded the max. retries
        }
      }
    }
