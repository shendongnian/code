    public class MyHandler : IHttpHandler
    {
        public MyHandler()
        {
        }
        public void ProcessRequest(HttpContext context)
        {
            var t = context.Request.QueryString["t"];
            context.Response.Write(string.Format("The value of the query string parameter \"t\" is {0}.", t));
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
