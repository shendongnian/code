    public class FooHandler : IHttpHandler, IReadOnlySessionState 
    {
        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            string user_id = context.Session["user_id"].ToString();
        }
    }
