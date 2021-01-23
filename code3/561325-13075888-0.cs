    public class FeaturedHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // Use a DataReader to stream back the images
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
