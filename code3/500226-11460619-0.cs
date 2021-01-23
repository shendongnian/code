    public class HtmlToPdfHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string url = context.Request["url"];
            PdfDocument doc = new PdfDocument();
            HtmlToPdf.ConvertUrl(url, doc);
            context.Response.ContentType = "application/pdf";
            doc.Save(context.Response.OutputStream);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
