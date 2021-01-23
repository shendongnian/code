    public class ImageHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
          string Name = "";
          if (context.Session["filename"] != null)
             Name = context.Session["filename"].ToString();
        }
    }
