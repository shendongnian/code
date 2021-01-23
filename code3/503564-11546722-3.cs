    public partial class App : Application
    {
    	void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    	{
    		ErrorEvent errorEvent = new ErrorEvent();
    		errorEvent.LogErrorEvent(e.Exception);
    		e.Handled = true;
    	}
    }
