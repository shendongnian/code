        void Application_BeginRequest(object sender, EventArgs e)
        {
            var currentRequest = HttpContext.Current.Request.Url.AbsolutePath;
            //Change 2
            if (currentRequest.Contains("ajax/book/")) // maybe you can use a generic path to all rewrites...
            {
                IgnoreWebServiceCall(HttpContext.Current);
                return;
            }
        }
        //Change 3
        private void IgnoreWebServiceCall(HttpContext context)
        {
            string svcPath = "/ajax/BookWebService.asmx";
            var currentRequest = HttpContext.Current.Request.Url.AbsolutePath;
            //You can use a switch or....
            if (currentRequest.Contains("ajax/book/list"))
            {
                svcPath += "/list";
            }
            int dotasmx = svcPath.IndexOf(".asmx");
            string path = svcPath.Substring(0, dotasmx + 5);
            string pathInfo = svcPath.Substring(dotasmx + 5);
            context.RewritePath(path, pathInfo, context.Request.Url.Query);
        }
