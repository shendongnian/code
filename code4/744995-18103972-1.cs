    Task<int> Foo(IEnumerable<int> items, CancellationToken token)
    {
        var tcs = new TaskCompletionSource<int>();
        token.Register(() => tcs.TrySetCanceled());
        var innerTask = Task.Factory.StartNew(() =>
        {
            foreach (var i in items)
                token.ThrowIfCancellationRequested();
            return 7;
        }, token);
        innerTask.ContinueWith(task => tcs.TrySetResult(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
        innerTask.ContinueWith(task => tcs.TrySetException(task.Exception), TaskContinuationOptions.OnlyOnFaulted);
        return tcs.Task;
    }
