    public class UrlMessingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
        }
        public void Dispose() { }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication) sender;
            var request = application.Request;
            var response = application.Response;
            
            var url = request.Url.AbsolutePath;
            if (url.Length > 1 && !url.EndsWith("/"))
            {
                response.Clear();
                response.Status = "301 Moved Permanently";
                response.StatusCode = (int)HttpStatusCode.MovedPermanently;
                response.AddHeader("Location", url + "/");
                response.End();
            }
           
        }
    }
