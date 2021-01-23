    /// <summary>
    /// Controller factory which uses an <see cref="IUnityContainer"/>.
    /// </summary>
    public class IocControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer _container;
        public IocControllerFactory(IUnityContainer container)
        {
            _container = container;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
                return _container.Resolve(controllerType) as IController;
            else
                return base.GetControllerInstance(requestContext, controllerType);
        }
    }
