    public class Global : System.Web.HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
        // Code that runs on application startup
        }
        void Application_BeginRequest(Object source, EventArgs e)
        {
            var httpApp = (HttpApplication)source;
            var uriObject = app.Context.Request.Url;
            //app.Context.Request.Url.OriginalString
        }
        void Application_Error(object sender, EventArgs e)
        {
        // Code that runs on application error
        }
        private void RegisterRoutes(RouteCollection routes)
        {
        // Code that runs on register routes
        }
    }
