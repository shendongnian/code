    public class CustomHttpHandler : IHttpHandler
    {
        // return true to reuse (cache server-side) the result 
        // for the same request parameters or false, otherwise 
        public bool IsReusable { get { return true; } }
        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            // do with the response what you must
        }
