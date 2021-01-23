    public class RemoteViewResult : ActionResult
    {
        private readonly Uri uri;
        public RemoteViewResult(Uri uri)
        {
            this.uri = uri;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead(this.uri))
                {
                    var response = context.RequestContext.HttpContext.Response; 
                    stream.CopyTo(response.OutputStream);
                    response.ContentType = client.ResponseHeaders[HttpResponseHeader.ContentType];
                }
            }
        }
    }
