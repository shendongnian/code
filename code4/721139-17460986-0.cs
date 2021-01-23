    public class RequiresParameterAttribute : ActionMethodSelectorAttribute {
    
       readonly string parameterName;
    
       public RequiresParameterAttribute(string parameterName) {
          this.parameterName = parameterName;
       }
    
       public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo) {
          return controllerContext.RouteData.Values[parameterName] != null;
       }
    }
