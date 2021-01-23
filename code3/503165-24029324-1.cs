    public class HandlerName : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
