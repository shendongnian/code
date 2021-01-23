    public class YourHttpHandler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string filePath = Common.FileHelper.UploadPath + context.Request.QueryString["file"];
            context.Response.ContentType = "your content type";
            context.Response.WriteFile(filePath);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
