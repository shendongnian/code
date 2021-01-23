       public class RouteControllerFactory : IControllerFactory
    {
        private readonly DefaultControllerFactory Default = new DefaultControllerFactory();
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return (requestContext.RouteData.Values.TryGetValue("controllerfactory") as IControllerFactory ?? Default).CreateController(requestContext, controllerName);
        }
        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return (requestContext.RouteData.Values.TryGetValue("controllerfactory") as IControllerFactory ?? Default).GetControllerSessionBehavior(requestContext, controllerName);
        }
        public void ReleaseController(IController controller)
        {
            Default.ReleaseController(controller);
        }
    }
