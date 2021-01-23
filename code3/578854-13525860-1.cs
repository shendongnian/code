    private void changeStatusLabel(string status)
    {
        progressLabel.Dispatcher.Invoke(new UIDelegate(delegate
        {
            progressLabel.Content = status;
        }));
    }
