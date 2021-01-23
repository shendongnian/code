    public class CustomAuthorizeAttribute : AuthorizeAttribute
      {
         protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
         {
            var clientId = Convert.ToInt32(actionContext.ControllerContext.RouteData.Values["clientid"]);
    
            // Check if user can access the client account.
    
         }
      }
