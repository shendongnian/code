    public class GetDownload : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["IDDownload"]))
            {
    	            context.Response.AddHeader("content-disposition", "attachment; filename=mydownload.zip");
    	            context.Response.ContentType = "application/octet-stream";
    	            byte[] rawBytes = // Insert loading file with IDDownload to byte array
    	            context.Response.OutputStream.Write(rawBytes, 0, rawBytes.Length);
            }
        }
    
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
