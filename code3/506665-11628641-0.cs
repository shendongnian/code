    public class Handler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
      {
          public void ProcessRequest(HttpContext context)
         {
               context.Session["sessionvariable"] = "value";
         }
      }
