    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() => 
            RunLongProcess(Application.Current.Dispatcher, myProgressBar));
    }
