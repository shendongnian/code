    public class HandleForbiddenRedirect : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                var config = (CustomErrorsSection)
                               WebConfigurationManager.GetSection("system.web/customErrors");
                string urlToRedirectTo = config.Errors["403"].Redirect;
                filterContext.Result = new RedirectResult(urlToRedirectTo);
            }
            base.OnActionExecuted(filterContext);
        }
    }
