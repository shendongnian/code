    public class MyImageHandler : IHttpHandler
    {
        public bool IsReusable { get { return true; } }
    
        public void ProcessRequest(HttpContext ctx)
        {
            Stream yourStream = ...; // This is where you get your data from your database
            ctx.Response.ContentType = "image/jpeg";
            yourStream.CopyTo(ctx.Response.OutputStream);
        }
    }
