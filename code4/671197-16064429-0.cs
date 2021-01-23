    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => DoWork())
            .ContinueWith(t => UpdateUIWithResults(t.Result)
            , CancellationToken.None
            , TaskContinuationOptions.None
            , TaskScheduler.FromCurrentSynchronizationContext());
    }
