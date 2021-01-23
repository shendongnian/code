    public class HandlerName : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
           //some code
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
