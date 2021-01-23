    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = base.Context;
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;
            var url = request.RawUrl;
            // and many other properties ...
        }
    }
