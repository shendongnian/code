    public class Handler : IHttpHandler
    {
        public void ProcessRequest (HttpContext context) 
        {
            // Access the raw HttpRequest and HttpResponse via context
        }
        public bool IsReusable 
        {
            get 
            {
                return false; // Define if ASP.NET may reuse instance for subsequent requests
            }
        }
    }
