    protected void Application_EndRequest(Object sender, EventArgs e)
    {
        if(Context.Items["AjaxPermissionDenied"] is bool) // FormsAuth module intercepts 401 response codes and does a redirect to the login page. 
        {
            Context.Response.StatusCode = 401;
            Context.Response.StatusDescription = "Permission Denied";
            Context.Response.End();
            return;
        }
    }
