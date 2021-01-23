    protected void Application_Error(object sender, EventArgs e)
    {
        var exception = Server.GetLastError();
        var httpException = exception as HttpException;
        if (exception is HttpException && ((HttpException)exception).GetHttpCode() == 404) 
        {
            Server.ClearError();
            // get the url
            var url = Request.RawUrl;
            var routeData = new RouteData();
            routeData.Values["controller"] = "Cms";
            routeData.Values["action"] = "Cms";
            routeData.Values["aspxerrorpath"] = url;
            IController cmsController = new CmsController();
            var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
            cmsController.Execute(rc);
        }
    }
