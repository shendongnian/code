    /// <summary>
    /// Summary description for MyHandler
    /// </summary>
    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(context.Request.QueryString["cid"]);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
