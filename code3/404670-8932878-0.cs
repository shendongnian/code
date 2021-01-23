    task.ContinueWith(t => 
    {
        MessageBox.Show("Error: " + t.Exception.InnerExceptions[0].Message);
    },
    CancellationToken.None, 
    TaskContinuationOptions.OnlyOnFaulted,
    TaskScheduler.FromCurrentSynchronizationContext());
