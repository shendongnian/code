    var tcs = new TaskCompletionSource<SomeResultType>();
    task.ContinueWith(completed =>
    {
        PropagateResult(completed, tcs);
    }, TaskContinuationOptions.ExecuteSynchronously);
    return tcs.Task;
    ...
    // Generally useful method...
    private static void PropagateResult<T>(Task<T> completedTask,
        TaskCompletionSource<T> completionSource)
    {
        switch (completedTask.Status)
        {
            case TaskStatus.Canceled:
                completionSource.TrySetCanceled();
                break;
            case TaskStatus.Faulted:
                // This is the bit you'd want to tweak
                completionSource.TrySetException(completedTask.Exception.InnerExceptions);
                break;
            case TaskStatus.RanToCompletion:
                completionSource.TrySetResult(completedTask.Result);
                break;
            default:
                throw new ArgumentException("Task was not completed");
        }
    }
