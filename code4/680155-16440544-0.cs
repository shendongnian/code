        void Application_Error(object sender, EventArgs e)
        {
            // this value can be fetched from config or depend on DEBUG smybol
            if (!handleErrors)
                return;
            var error = Server.GetLastError();
            var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;
            if (code == 404)
            {
                // do something if page was not found. log for instance
            }
            else
            {
                // collect request info and log exception
            }
            // pass exception to ErrorsController
            Request.RequestContext.RouteData.Values["ex"] = error;
            // execute controller action
            IController errorController = new ErrorsController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), Request.RequestContext.RouteData));
        }
