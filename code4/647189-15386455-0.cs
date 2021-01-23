    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session != null)
        {
            // Restore session if session is lost but cookie is not
            // HttpContext.Current.Session["user_id"] == null &&
            if (HttpContext.Current.Request.Cookies["hash"] != null)
            {
                // do your job here
                RestoreSessionMethod();
            }
        }
    }
