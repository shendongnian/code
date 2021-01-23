    public class MyActionInvoker : ControllerActionInvoker
    {
        protected override ActionDescriptor FindAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string actionName)
        {
            var action = base.FindAction(controllerContext, controllerDescriptor, actionName);
    
            if (action != null)
            {
                var reflectedActionDecsriptor = action as ReflectedActionDescriptor;
                if (reflectedActionDecsriptor != null)
                {
                    if (new MyActionMethodSelectorAttribute().IsValidForRequest(controllerContext, reflectedActionDecsriptor.MethodInfo))
                    {
                        return null;
                    }
                }
            }
    
            return action;
        }
    }
