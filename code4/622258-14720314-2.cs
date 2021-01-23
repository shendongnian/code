    var tcs = new TaskCompletionSource<Task<bool>>();
    foreach (var task in tasks)
    {
        task.ContinueWith((t, state) =>
        {
            if (t.Result)
            {
                ((TaskCompletionSource<Task<bool>>)state).TrySetResult(t);
            }
        },
            tcs,
            TaskContinuationOptions.OnlyOnRanToCompletion |
            TaskContinuationOptions.ExecuteSynchronously);
    }
    var firstTaskToComplete = tcs.Task;
