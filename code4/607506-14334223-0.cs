    public class UploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var uploadedFiles = context.Request.Files;
            if (uploadedFiles != null)
            {
                foreach (HttpPostedFile file in uploadedFiles)
                {
                    // store the file somewhere on the server
                    // For example:
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(context.Server.MapPath("~/App_Data/uploads"), fileName); 
                    file.SaveAs(path);
                }
            }
            context.Response.ContentType = "application/json";
            context.Response.Write("{\"success\":true}");
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
