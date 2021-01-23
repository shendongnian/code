    public class ReportResult : ActionResult
    {
        private readonly string _filename;
        public ReportResult(string filename)
        {
            _filename = filename;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            var cd = new ContentDisposition
            {
                FileName = _filename,
                Inline = false
            };
            var response = context.HttpContext.Response;
            response.ContentType = "application/pdf";
            response.Headers["Content-Disposition"] = cd.ToString();
    
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://foo.com/" + _filename))
            {
                // in .NET 4.0 implementation this will process in chunks
                // of 4KB
                stream.CopyTo(response.OutputStream);
            }
        }
    }
