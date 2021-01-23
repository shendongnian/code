    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.OutputStream.Write(imageData, 0, imageData.Length);
            context.Response.ContentType = "image/JPEG";
        }
    }
