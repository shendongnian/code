    public class Download : IHttpHandler {
        public void ProcessRequest (HttpContext context) {
            string filename = context.Request.QueryString["file"];
            string file = context.Server.MapPath(filename);
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename));
            try
            {
                context.Response.TransmitFile(file);
            }
            catch (Exception ex)
            {
                SendFailedDownload(filename, context);
            }
            finally
            {
            }
        }
    }
