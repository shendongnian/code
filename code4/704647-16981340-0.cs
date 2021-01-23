       protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Context.Error;
    
            if (ex is HttpUnhandledException)
            {
                ex = Context.Error.InnerException;
            }
    
            if (ex.GetType().Name == "FileNotFoundException")
            {
                //ignore
            }
            else
            {
                try
                {
                    if ((ex as HttpException).GetHttpCode() == 404)
                    {
                        // Page Not found, redirect
                        if (!ex.Message.Contains("error.aspx"))
                        {
                            Response.Status = "301 Moved Permanently";
                            Response.AddHeader("Location", "~/error.aspx");
                            Response.End();
                        }
                   
                    }
                }
                catch (Exception ThrownException)
                {
                  //log
                }
            }
        }
