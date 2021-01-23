    public class XframeOptionsFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnResultExecuted(System.Web.Mvc.ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.AddHeader("x-frame-options", "Deny");
        }
    }
