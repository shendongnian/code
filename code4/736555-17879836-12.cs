    public class HomeController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                var config = (CustomErrorsSection)
                               WebConfigurationManager.GetSection("system.web/customErrors");
                string urlToRedirectTo = config.Errors["403"].Redirect;
                filterContext.Result = Redirect(urlToRedirectTo);
            }
            base.OnActionExecuted(filterContext);
        }
        
        public ActionResult Edit(int idObject)
        {
             if(!user.OnwsObject(idObject))
             {
                 Response.StatusCode = 403;
             }
             return View();
        }
    }
