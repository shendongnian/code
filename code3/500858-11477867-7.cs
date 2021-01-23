    public class UploadImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var uploadedImage = context.Request.Files["image"];
            using (var image = Image.FromStream(uploadedImage.InputStream))
            {
                image.Save(@"c:\work\test.png");
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("upload successful");
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
