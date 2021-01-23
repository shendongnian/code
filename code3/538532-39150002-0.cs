    public abstract class BaseController : Controller
    {
        [ValidateInput(false)]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((Request.Unvalidated["api"] == null || string.IsNullOrEmpty(Request.Unvalidated["api"])))
                return;
            if ((Request.Unvalidated["api"] != null && !string.IsNullOrEmpty(Request.Unvalidated["api"])))
            {
                if (Session["api"] == null)
                {
                    Session["api"] = Request.Unvalidated["api"];
                }
            }
        }
    }
