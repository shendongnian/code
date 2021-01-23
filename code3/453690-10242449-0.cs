      [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class, AllowMultiple = false)]
    public class  MyAuthorizeAttribute : AuthorizeAttribute
      {
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
      base.OnAuthorization(filterContext);
         var ctx = filterContext.HttpContext;
          var name = ctx.User.Identity.Name;
 
      //get user id from db where username= name   
         var urlId = Int32.Parse(ctx.Request.Params["id"]);
         if (userId!=urlId)  filterContext.Result = new HttpUnauthorizedResult();
    }
    }
