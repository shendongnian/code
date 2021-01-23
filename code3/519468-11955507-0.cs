    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        private HttpVerbs mOnVerbs;
        public MyActionFilterAttribute(HttpVerbs onVerbs)
        {
            mOnVerbs = onVerbs;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (mOnVerbs.HasFlag(HttpVerbs.Post)) { }
            else if (mOnVerbs.HasFlag(HttpVerbs.Get)) { }
            base.OnActionExecuting(filterContext);
        }
    }
    [MyActionFilter(HttpVerbs.Get | HttpVerbs.Post)]
    public ActionResult Index()
    {
    }
