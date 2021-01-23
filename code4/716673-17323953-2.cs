    Application.Current.DispatcherUnhandledException += OnDispatcherUnhandledException;
    
    void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs)
    {
            // exception handling goes here
    }
