    protected override void OnStartup(StartupEventArgs e)
    {
        Dispatcher.UnhandledException += Dispatcher_UnhandledException;
    }
    private void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        HandleException(e.Exception);//your handler
        e.Handled = true;
    }
