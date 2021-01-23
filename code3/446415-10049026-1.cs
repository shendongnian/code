    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var stream = context.Request.InputStream;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            string xml = Encoding.UTF8.GetString(buffer);
            ... do something with the XML
            // We only set the HTTP status code to 202 indicating to the
            // client that the request has been accepted for processing
            // but we leave an empty response body
            context.Response.StatusCode = 202;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
