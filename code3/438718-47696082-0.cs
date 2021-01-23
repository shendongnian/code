    int retries = 0;
	int maxRetryAttempts = 5;
    
    var retryStorageExceptionPolicy = Policy
    	.Handle<StorageException>()
    	.WaitAndRetry(maxRetryAttempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
    		onRetry: (exception, calculatedWaitDuration) =>
    		{
    			retries++;
    			loggingService.LogWarning(exception,
    				new Dictionary<string, string>
    				{
    					{"Message", $"A StorageException occurred when trying to Execute Query With Retry. This exception has been caught and will be retried." },
    					{"Current Retry Count", retries.ToString() },
    					{"tableName", table.Name},
    					{"ExtendedErrorInformation.ErrorCode", (exception as StorageException)?.RequestInformation.ExtendedErrorInformation.ErrorCode },
    					{"ExtendedErrorInformation.ErrorMessage", (exception as StorageException)?.RequestInformation.ExtendedErrorInformation.ErrorMessage }
    				});
    		});
    
    retryStorageExceptionPolicy
    	.ExecuteAndCapture(() =>
    	{
    		// your method accessing Azure Storage here                
    	});
