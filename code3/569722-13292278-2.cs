    public class SignUpSelector : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
             return (controllerContext.HttpContext.Request.Form["AccountType"] + "Registration" == methodInfo.Name);
        }
    }
