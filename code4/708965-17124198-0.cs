    private void Log(string log)
    {
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            App.ViewModel.TxtStatus = log + App.ViewModel.TxtStatus;
        });
    }
