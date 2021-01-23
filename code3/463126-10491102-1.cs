    //error checking
    var result = new TaskCompletionSource<object>();
    
    Func<Task, Task> retryRec = null; //declare, then assign
    retryRec = (t) => { if (shouldRetry(t))
                            return action().ContinueWith(retryRec).Unwrap();
                        else
                        {
                            if (t.IsFaulted) 
                                result.TrySetException(t.Exception);
                            //and so on
                            return result.Task; //need to return something
                         }
                      };
     action().ContinueWith(retryRec);
     return result.Task;
