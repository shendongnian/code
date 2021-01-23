    public class FeedbkPrincipalIntoViewBagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var principal = filterContext.HttpContext.User as FeedbkPrincipal;
            if (principal != null)
            {
                filterContext.Controller.ViewBag.Identity = principal.Identity as FeedbkIdentity;
            }
        }
    }
