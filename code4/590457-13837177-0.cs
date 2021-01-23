    protected void Application_Error(object sender, EventArgs e)
    {
       Exception ex = System.Web.HttpContext.Current.Error;
       //Use here
       System.Web.HttpContext.Current.ClearError();
       //Write custom error page in response
       System.Web.HttpContext.Current.Response.Write(customErrorPageContent);
       System.Web.HttpContext.Current.Response.StatusCode = 500;
    }
