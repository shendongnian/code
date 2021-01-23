    private void handler(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => getInfoFromDB())
            .ContinueWith(task => label1.Text = task.Result,
            CancellationToken.None, TaskContinuationOptions.None,
            TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    private string getInfoFromDB()
    {
        Thread.Sleep(2000);//simulate long IO operation
        return "Hello world!";
    }
