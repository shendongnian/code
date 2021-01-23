    // Cancellation token for the latest task.
    private CancellationTokenSource cancellationTokenSource;
    private void OnClick(object sender, ItemClickEventArgs e)
    {
        // If a cancellation token already exists (for a previous task),
        // cancel it.
        if (this.cancellationTokenSource != null)
            this.cancellationTokenSource.Cancel();
        // Create a new cancellation token for the new task.
        this.cancellationTokenSource = new CancellationTokenSource();
        // Start the new task.
        var task = Task.Factory.StartNew<object>(LongMethod);
        // Set the task continuation to execute on UI thread,
        // but only if the associated cancellation token
        // has not been cancelled.
        task.ContinueWith(TaskCallback, 
            cancellationTokenSource.Token, 
            TaskContinuationOptions.NotOnCanceled, 
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    private void TaskCallback(Task<object> task)
    {
        // Just update UI
    }
