    protected void Application_Error(object sender, EventArgs e)
    {
        // Grab the last exception
        Exception ex = Server.GetLastError();
        // put it in session
        Session["Last_Exception"] = ex;
 
        // clear the last error to stop .net clearing session
        Server.ClearError();
        // The above stops the auto-redirect - so do a redirect using the default redirect from the customErrors section of the web.config!
        var customerrors = (CustomErrorsSection)WebConfigurationManager.OpenWebConfiguration("/").GetSection("system.web/customErrors");
        Response.Redirect(customerrors.DefaultRedirect);
    }
