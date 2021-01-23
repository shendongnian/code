    public class RequiresParameterAttribute : ActionMethodSelectorAttribute
    {
        readonly string[] parameterName;
        public RequiresParameterAttribute(string[] parameterName)
        {
            this.parameterName = parameterName;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            //somehow, in my version of MVC controllerContext.RouteData.Values was not returning querystring parameters at all...
            var queryString = controllerContext.RequestContext.HttpContext.Request.QueryString; 
            
            foreach (string param in parameterName)
            {
                if (queryString.GetValues(param) == null)
                    return false;
            }
            return true;
        }
    }
