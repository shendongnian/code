    public class MasterController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = Session["_User"] as User;
            if (user== null)
            {
                filterContext.Result = this.RedirectToAction("Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
