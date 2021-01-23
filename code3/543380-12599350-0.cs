    public class MyViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var controllerType = controllerContext.Controller.GetType();
            var actionDescriptor = 
                new ReflectedControllerDescriptor(controllerType)
                .FindAction(
                    controllerContext, 
                    controllerContext.RouteData.GetRequiredString("action")
                );
            var attributes = actionDescriptor.GetCustomAttributes(typeof(...), false);
    
            // TODO: do something with the attributes that you retrieved
            // from the current action
        }    
    }
