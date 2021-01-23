    public class FirstTimePageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session != null)
            {
              var user = filterContext.HttpContext.Session["User"] as User;
              if(user != null && string.IsNullOrEmpty(user.FirstName))
                  new RedirectResult("/home?r=enter_first_name");
              else
              {
                  //what ever you want
              }
             }
        }
    }
