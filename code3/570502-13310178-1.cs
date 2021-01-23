    public class FirstTimeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session != null)
            {
              var user = filterContext.HttpContext.Session["User"] as User;
              if(user != null && string.IsNullOrEmpty(user.FirstName))
                  filterContext.Result = new RedirectResult("/home/firstname");
              else
              {
                  //what ever you want, or nothing at all
              }
             }
        }
    }
