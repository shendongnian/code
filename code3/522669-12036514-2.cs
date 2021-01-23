    private void btnClick_Click(object sender, RoutedEventArgs e)
    {
    busyIndicator.IsBusy = true;
    //busyIndicator.BusyContent = "Fetching Data...";
    
    ThreadPool.QueueUserWorkItem((state) =>
    {
    Thread.Sleep(3 * 1000);
    Dispatcher.BeginInvoke(() => busyIndicator.IsBusy = false);
    });
    }
