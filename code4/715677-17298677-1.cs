    private void AsyncCallback(IAsyncResult result){
        var dispatcher = Dispatcher.CurrentDispatcher;
        dispatcher.Invoke(new Action(() =>
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
