    Dispatcher.Invoke(new Action(() => ConnectFtp()));
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate(object s, DoWorkEventArgs args)
            {
                ConnectFtp();
            };
            worker.RunWorkerAsync();
    }
    
    private void ConnectFtp()
    {
         // Here i'm connecting to a ftp server. 
         // Do some I/O operation
         // Now time to update UI controls so we invoke on Dispatcher UI thread
         Dispatcher.Invoke(new Action(() =>
         {
             lblMessage.Text = "Process finished";
             // Some other UI updates..
         }));
    }
