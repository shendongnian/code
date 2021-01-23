    [AttributeUsageAttribute(AttributeTargets.Class|AttributeTargets.Method, 
      Inherited = true, AllowMultiple = true)]
    public class InternalAuthorizeV2Attribute : System.Web.Mvc.AuthorizeAttribute {
      protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext) {
        return false; // breakpoint here, and this should force an authorization failure
      }
      public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
      {
        base.OnAuthorization(filterContext); // breakpoint here
      }
    }
