    public static class RequestContextExtensions
    {
        public static MethodInfo GetActionMethod(this RequestContext requestContext)
        {
            Type controllerType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == requestContext.RouteData.Values["controller"].ToString());
            ControllerContext controllerContext = new ControllerContext(requestContext, Activator.CreateInstance(controllerType) as ControllerBase);
            ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controllerType);
            ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(controllerContext, controllerContext.RouteData.Values["action"].ToString());
            return (actionDescriptor as ReflectedActionDescriptor).MethodInfo;
        }
    }
