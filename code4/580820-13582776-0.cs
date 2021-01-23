    private async void Click_Button(object sender, RoutedEventArgs e)
    {
        await Task.Run((Func<Task>)BgDoWork);
        BgOnRunWorkerCompleted();
    }
    private void BgOnRunWorkerCompleted()
    {
    }
    private async Task BgDoWork()
    {
        await Method();
    }
