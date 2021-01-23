    // enable unit test to mock a dispatcher
    var dispatcher = Dispatcher.CurrentDispatcher;
    if (Application.Current != null)
    {
        // use the application dispatcher if running from the software
        dispatcher = Application.Current.Dispatcher;
    }
    if (dispatcher != null)
    {
        // delegate the operation to UI thread.
        dispatcher.Invoke(
            delegate
            {
                MessageBox.Show("Opeartion could not be completed. Please try again.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            });
    }
