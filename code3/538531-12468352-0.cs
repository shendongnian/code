    public abstract class BaseController : Controller
    {
    [ValidateInput(false)]
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if ((Request.QueryString["api"] == null || string.IsNullOrEmpty(Request.QueryString["api"])))
            return;
        if ((Request.QueryString["api"] != null && !string.IsNullOrEmpty(Request.QueryString["api"])))
        {
            if (Session["api"] == null)
            {
                Session["api"] = Request.Params["api"];
            }
        }
    }
