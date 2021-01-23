    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var stream = context.Request.InputStream;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            string xml = Encoding.UTF8.GetString(buffer);
            ...
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
