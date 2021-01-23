    public class HandlerName : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
          // some code
        }
        public void ProcessRequest(HttpContext context, string someString)
        {
           // do your coding here
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
