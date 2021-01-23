	static Task<T> RetryWhile<T>(
        Func<int, Task<T>> func, 
        Func<Exception, int, bool> shouldRetry )
	{
		return RetryWhile<T>( func, shouldRetry, new TaskCompletionSource<T>(), 0, Enumerable.Empty<Exception>() );
	}
	static Task<T> RetryWhile<T>( 
	    Func<int, Task<T>> func, 
	    Func<Exception, int, bool> shouldRetry, 
	    TaskCompletionSource<T> tcs, 
	    int previousAttempts, IEnumerable<Exception> previousExceptions )
	{
		func( previousAttempts ).ContinueWith( antecedent =>
		{
			if ( antecedent.IsFaulted )
			{
				var antecedentException = antecedent.Exception;
				var allSoFar = previousExceptions
				    .Concat( antecedentException.Flatten().InnerExceptions );
				if ( shouldRetry( antecedentException, previousAttempts ) )
					RetryWhile( func,shouldRetry,previousAttempts+1, tcs, allSoFar);
				else
					tcs.SetException( allLoggedExceptions );
			}
			else
				tcs.SetResult( antecedent.Result );
		}, TaskContinuationOptions.ExecuteSynchronously );
		return tcs.Task;
	}
