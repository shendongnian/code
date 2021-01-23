    public class TeamMemberAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        base.OnActionExecuting(filterContext);
        var httpContext = filterContext.RequestContext.HttpContext;
    
        Team team = filterContext.ActionParameters["team"] as Team;
        long userId = long.Parse(httpContext.User.Identity.Name);
    
        if (team == null || team.Members.Where(m => m.Id == userId).Count() == 0)
        {
            httpContext.Response.StatusCode = 403;
            ViewResult insufficientPermssions = new ViewResult();
            insufficientPermssions.ViewName = "InsufficientPermissions";
            filterContext.Result = insufficientPermssions;
        }
      }
    }
