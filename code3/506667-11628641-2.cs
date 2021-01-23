    public class Handler : IHttpHandler, IReadOnlySessionState
    {
       public bool IsReusable { get { return true; } }
       
       public void ProcessRequest(HttpContext ctx)
       {
           ctx.Response.Write(ctx.Session["fred"]);
       }
    }
