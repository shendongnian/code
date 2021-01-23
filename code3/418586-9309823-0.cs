    public class MyImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string imageId = context.Request["imageId"];
            // use the image id to fetch the photo bytes from the backend
            byte[] photoBytes = ...
            // ensure the content type matches the one of your image
            context.Response.ContentType = "image/png";
            context.Response.BinaryWrite(photoBytes);
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
