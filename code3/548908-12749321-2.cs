    public void InfoLabel2(string value)
    {
        Task.Factory.StartNew(() => Thread.Sleep(1000)) //could use Task.Delay if you have 4.5
            .ContinueWith(task => label1.Text = value
                , CancellationToken.None
                , TaskContinuationOptions.None
                , TaskScheduler.FromCurrentSynchronizationContext());
    }
