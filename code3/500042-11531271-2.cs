        void PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            if(HttpRuntime.UsingIntegratedPipeline)
            {
                application.Response.Headers.Remove("Server");
                application.Response.Headers.Remove("Expires");
                application.Response.Headers.Remove("Cache-Control");
                application.Response.AddHeader("Cache-Control", "max-age=3600, public");
            }
        }
