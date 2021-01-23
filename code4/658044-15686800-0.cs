    public class RedirectOnCat : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(MyService.IsCat == false)
                filterContext.Result = new RedirectResult(/* whatever you need here */);
        }
    }
