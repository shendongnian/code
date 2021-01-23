     new TaskFactory( CancellationToken.None, 
                      TaskCreationOptions.None, 
                      TaskContinuationOptions.None, 
                      TaskScheduler.Default )
          .StartNew<Task<TResult>>( func )
          .Unwrap<TResult>()
          .GetAwaiter()
          .GetResult();
