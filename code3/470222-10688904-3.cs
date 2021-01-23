    static Task<T> WrapTaskForCancellation<T>(
        CancellationToken cancellationToken, Task<T> task)
    {
        var tcs = new TaskCompletionSource<T>();
        if (cancellationToken.IsCancellationRequested)
        {
            tcs.TrySetCanceled();
        }
        else
        {
            cancellationToken.Register(() =>
            {
                tcs.TrySetCanceled();
            });
            task.ContinueWith(antecedent =>
            {
                if (antecedent.IsFaulted)
                {
                    tcs.TrySetException(antecedent.Exception.GetBaseException());
                }
                else if (antecedent.IsCanceled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(antecedent.Result);
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
        }
        return tcs.Task;
    }
