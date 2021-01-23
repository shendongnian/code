    Hide()
    if(a > b)
    {
        label.Text = "a is greater than b";
        Show();
        Task.Factory
            .StartNew(() => Thread.Sleep(5000))
            .ContinueWith(() => Close(), TaskScheduler.FromCurrentSynchronizationContext());
    }
