    //In Global.asax
    private void Application_BeginRequest(Object source, EventArgs e) {
        Logger.Current.Log("Request made to Application_BeginRequest")
    }
    //In your HttpModule
        private void context_BeginRequest(object sender, EventArgs e)
        {
            //Log before any of your other code
            Logger.Current.Log("Request made to context_BeginRequest")
            try
            {
                  // your code
            }
            catch (Exception ex)
            {
                // log the exception first in case this is the problem
                Logger.Current.LogError(ex);
                if (ex is ThreadAbortException)
                    return;
            }
        }
