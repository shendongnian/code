    public class UnityHttpControllerActivator : IHttpControllerActivator
    {
        private IUnityContainer _container;
        public UnityHttpControllerActivator(IUnityContainer container)
        {
            _container = container;
        }
        public IHttpController Create(HttpControllerContext controllerContext, Type controllerType)
        {
            return (IHttpController)_container.Resolve(controllerType);
        }
    }
