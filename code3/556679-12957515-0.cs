    public class ExampleHttpHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        } 
        public void ProcessRequest(HttpContext context)
        {    
            context.Session["test"] = "test";
            context.Response.Write(context.Session["test"]);
        }
    }
