    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Dispatcher callback = Dispatcher.CurrentDispatcher;
        ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
        {
             //Do some work
             System.Threading.Thread.Sleep(2000);
             //callbackk to ui thread to do ui work. You can also use BeginInvoke...
             callback.Invoke(new Action(() => {ConvertDataTabControl.SelectedIndex = 1;}));
             
             //Do some more work
             System.Threading.Thread.Sleep(2000);
             ...
        }
    }
