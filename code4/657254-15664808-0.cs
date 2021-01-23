    public class CustomAuthorizeAttribute : AuthorizeAttribute
       {
            public string currentAction { get; set; }
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
               if (currentAction != "notallowed")
                {
                    HandleUnauthorizedRequest(filterContext);
                }
            }
        }
     protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            context.Result = new RedirectResult("/home/login");
        }
