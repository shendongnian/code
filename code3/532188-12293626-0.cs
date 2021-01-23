    BackgroundWorker _worker = new BackgroundWorker();
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _worker.DoWork += delegate(object s, DoWorkEventArgs args)
        {
            ConnectFtp();
        };
        _worker.RunWorkerAsync();
    }
    private void ConnectFtp()
    {
     //here i'm connecting to a ftp server. 
    }
