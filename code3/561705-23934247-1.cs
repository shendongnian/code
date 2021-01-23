    public class MyHttpModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.PostAuthenticateRequest += app_PostAuthenticateRequest;
        }
        void app_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var queryString = context.Response.QueryString;
            // queryString["op"] will never fail, just compare its value
            if (queryString["op"] == "ChangeService")
            {
                context.RemapHandler(new MyHttpHandler());
            }
        }
        public void Dispose() { }
    }
