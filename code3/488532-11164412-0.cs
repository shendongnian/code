    private CancellationTokenSource cancellationTokenSource;
    private void OnClick(object sender, ItemClickEventArgs e)
    {
        if (cancellationTokenSource != null)
            cancellationTokenSource.Cancel();
        cancellationTokenSource = new CancellationTokenSource();
        var task = Task.Factory.StartNew<object>(LongMethod);
        task.ContinueWith(TaskCallback, 
            cancellationTokenSource.Token, 
            TaskContinuationOptions.NotOnCanceled, 
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    private void TaskCallback(Task<object> task)
    {
        // just update UI
    }
