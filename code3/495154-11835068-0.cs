    public class MyHttpHandler : IHttpHandler
    {
       public void ProcessRequest(HttpContext context)
       {
          // prepare image like you did
          memStream.WriteTo(context.Response.OutputStream);
       }
       // Override the IsReusable property.
       public bool IsReusable
       {
          get { return true; }
       }
    }
