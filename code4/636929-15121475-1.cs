    public async void Loginbtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        actionReport.Text = "Trying to Connecting to the database";
        Task.Delay(2).ContinueWith(_ =>
            {
                actionReport.Text = "Connected";
            }, CancellationToken.None
            , TaskContinuationOptions.None
            , TaskScheduler.FromCurrentSynchronizationContext());
    }
