    private async void OnClick(object sender, RoutedEventArgs e)
    {
        Dispatcher.UnhandledException += OnUnhandledException;
        try
        {
            await Dispatcher.BeginInvoke((Action)(Throw));
        }
        catch
        {
            // The exception is not handled here but in the unhandled exception handler.
            MessageBox.Show("Catched BeginInvoke.");
        }
        try
        {
           await Dispatcher.InvokeAsync((Action)Throw);
        }
        catch
        {
            MessageBox.Show("Catched InvokeAsync.");
        }
    }
    private void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show("Catched UnhandledException");
    }
    private void Throw()
    {
        throw new Exception();
    }
