    using System.Web.Sessionstate;
     public class Handler: IHttpHandler, IRequiresSessionState
     {
        public void ProcessRequest(HttpContext context)
        {
           context.Session["YourSessionVar"] = yourStringVar;
        }
     }
