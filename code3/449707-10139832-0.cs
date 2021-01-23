    private void Application_Error(object sender, EventArgs e)
    {
        try
        {
            //
            // Try to be as "defensive" as possible, to ensure gathering of max. amount of info.
            //
            HttpApplication app = (HttpApplication) sender;
            if(null != app.Context)
            {
                HttpContext context = app.Context;
                if(null != context.AllErrors)
                {
                    foreach(Exception ex in context.AllErrors)
                    {
                        // Log the **ex** or send it via mail.
                    }
                }
                context.ClearError();
                context.Server.Transfer("~/YourErrorPage");
            }
        }
        catch
        {
            HttpContext.Current.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
