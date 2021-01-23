    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Task.Factory
            .StartNew(this.Worker)
            .ContinueWith(this.OnWorkerCompleted);
    }
    public void Worker()
    {
        Dispatcher.Invoke(new Action(() =>
        {
            btn1.IsEnabled = false;
        }));
        // your stuff here...
    }
    private void OnWorkerCompleted(Task obj)
    {
        Dispatcher.Invoke(new Action(() =>
        {
            btn1.IsEnabled = true;
        }));
    }
