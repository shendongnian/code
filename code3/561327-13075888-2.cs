    public class FeaturedHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            ...
        }
    
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
