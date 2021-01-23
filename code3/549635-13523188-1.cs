    void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var comException = e.Exception as System.Runtime.InteropServices.COMException;
        if (comException != null && comException.ErrorCode == -2147221040)
             e.Handled = true;
    }
