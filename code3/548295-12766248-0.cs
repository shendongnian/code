     public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            this.Exit += new ExitEventHandler(App_Exit);
        }
        void App_Exit(object sender, ExitEventArgs e)
        {
            //Check stack trace.
        }
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //Check if this event handler get executed and from where control is coming to this method.
        }
    }
