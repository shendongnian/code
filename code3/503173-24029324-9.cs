    public class HandlerName : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
          string contextData = (string)(HttpContext.Current.Items["ModuleInfo"]);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    
    
