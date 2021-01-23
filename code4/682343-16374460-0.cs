    public class AdminAuthorize : ActionFilterAttribute 
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            var currentUser = ((AdminController)filterContext.Controller).CurrentUser;
            // do what you need with currentUser
        }
    }
