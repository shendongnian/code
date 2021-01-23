    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //Retrieve the image using whatever method and identifier you used
            byte[] imageData = get_item(context.Request["ID"]);
            if (imageData.Count > 0)
            {
                context.Response.OutputStream.Write(imageData, 0, imageData.Length);
                context.Response.ContentType = "image/JPEG";
            }
        }
    }
