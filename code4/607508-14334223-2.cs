    public class UploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var request = context.Request;
            var formUpload = request.Files.Count > 0;
            var xFileName = request.Headers["X-File-Name"];
            var qqFile = request["qqfile"];
            var formFilename = formUpload ? request.Files[0].FileName : null;
            var filename = xFileName ?? qqFile ?? formFilename;
            var inputStream = formUpload ? request.Files[0].InputStream : request.InputStream;
            var filePath = Path.Combine(context.Server.MapPath("~/App_Data"), filename);
            using (var fileStream = File.OpenWrite(filePath))
            {
                inputStream.CopyTo(fileStream);
            }
            context.Response.ContentType = "application/json";
            context.Response.Write("{\"success\":true}");
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
