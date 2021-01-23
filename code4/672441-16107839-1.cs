    public class RedirectHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
    
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Redirect("http://www.abc.com");
        }
    }
