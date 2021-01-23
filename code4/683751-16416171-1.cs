    void Application_Error(object sender, EventArgs e)
            {
                // Code that runs when an unhandled error occurs
                // Get the error details
                Exception lastErrorWrapper = Server.GetLastError();            
                System.Diagnostics.Debug.Print(lastErrorWrapper.Message);
                Response.Redirect("~/error.aspx?q=" + lastErrorWrapper.Message);
            }
