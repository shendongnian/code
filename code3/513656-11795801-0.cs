    public class CustomImageHandler : IHttpHandler
    {
		public void ProcessRequest(HttpContext context)
        {
       		// here you'll use context.Response to set the appropriate
            // content and http headers
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "image/png";
            byte[] responseImage = GenerateImage();
            context.Response.BinaryWrite(responseImage);
            context.Response.Flush();
        }
    }
