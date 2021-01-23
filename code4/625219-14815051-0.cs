    public static IEnumerable<Task<T>> Order<T>(this IEnumerable<Task<T>> tasks)
    {
        var input = tasks.ToList();
        var output = input.Select(task => new TaskCompletionSource<T>());
        var collection = new BlockingCollection<TaskCompletionSource<T>>();
        foreach (var tcs in output)
            collection.Add(tcs);
        foreach (var task in input)
        {
            task.ContinueWith(t =>
            {
                var tcs = collection.Take();
                switch (task.Status)
                {
                    case TaskStatus.Canceled:
                        tcs.TrySetCanceled();
                        break;
                    case TaskStatus.Faulted:
                        tcs.TrySetException(task.Exception.InnerExceptions);
                        break;
                    case TaskStatus.RanToCompletion:
                        tcs.TrySetResult(task.Result);
                        break;
                }
            }
            , CancellationToken.None
            , TaskContinuationOptions.ExecuteSynchronously
            , TaskScheduler.Default);
        }
        return output.Select(tcs => tcs.Task);
    }
