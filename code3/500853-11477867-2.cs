    public class UploadImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var imageBase64String = context.Request.Form["image"];
            var imageBuffer = Convert.FromBase64String(imageBase64String);
            using (var stream = new MemoryStream(imageBuffer))
            using (var image = Image.FromStream(stream))
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
