    [AttributeUsageAttribute(AttributeTargets.Class|AttributeTargets.Method, 
      Inherited = true, AllowMultiple = true)]
    public class OverrideAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute {
      public override void OnAuthorization(AuthorizationContext filterContext)
      {
        base.OnAuthorization(filterContext); // breakpoint here
      }
    }
