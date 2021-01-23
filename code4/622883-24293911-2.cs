    public class CustomAuthorizeAttribute : AuthorizeAttribute
      {
         protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
         {
            var clientId = actionContext.ControllerContext.RouteData.Values["clientid"];
    
         }
      }
