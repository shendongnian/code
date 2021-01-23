        public App()
        {
            ...
            this.UnhandledException += this.Application_UnhandledException;
            ...
        }
        private void Application_UnhandledException(object sender, 
                ApplicationUnhandledExceptionEventArgs e)
            {
                if(e.Exception is YourException){
                    //show a message box or whatever you need
                    e.Handled = true; //if you don't want to propagate
                }
            }
