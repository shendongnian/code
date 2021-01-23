    public App()
    {
        this.Dispatcher.UnhandledException += 
            new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(
                Dispatcher_UnhandledException);
    }
    
    void Dispatcher_UnhandledException(object sender, 
     System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        if(e.Exception is YourException){
                //show a message box or whatever you need
                e.Handled = true; //if you don't want to propagate
        }
    }
