    public class Upload: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;
            response.ContentType = "text/plain";
            response.Write(request.Headers.ToString());
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
