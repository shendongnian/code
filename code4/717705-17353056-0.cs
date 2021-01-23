    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        radBusyIndicator.IsBusy = true;
        LoginButton.IsEnabled = false; // Prevent clicking twice
        string error = string.Empty;
        long userId = 0;
        // Start this in the background
        var task = Task.Factory.StartNew(()=>
        {
            //Login code here....
            //...........  bunch of other code. etc..
        });
        // Run, on the UI thread, cleanup code afterwards
        task.ContinueWith(t =>
        {
            // TODO: Handle exceptions by checking t.Exception or similar...
            radBusyIndicator.IsBusy = false;
            LoginButton.IsEnabled = true;
        }, TaskScheduler.FromCurrentSynchronizationContext());
     }
