    public class UnityHttpControllerActivator : System.Web.Http.Dispatcher.IHttpControllerActivator
        {
            private IUnityContainer _container;
            public UnityHttpControllerActivator(IUnityContainer container)
            {
                _container = container;
            }
            public System.Web.Http.Controllers.IHttpController Create(System.Web.Http.Controllers.HttpControllerContext controllerContext, Type controllerType)
            {
                return (System.Web.Http.Controllers.IHttpController)_container.Resolve(controllerType);
            }
        }
