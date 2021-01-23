    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            byte[] imageBackground = new byte[] { 137,80,78,71,13,10,26,10,0,0,0,13,73,72,68,... };
            response.OutputStream.Write(imageBackground, 0, imageBackground.Length);
            response.ContentType = "image/jpeg";
        }
    }
