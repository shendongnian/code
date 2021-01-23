    public class UnityControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// Initializes a new instance of the <see cref="UnityControllerFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="controllerActivator">The controller activator.</param>
        public UnityControllerFactory(IUnityContainer container, IControllerActivator controllerActivator)
            : base(controllerActivator)
        {
            ////Guard.ArgumentNotNull(container, "container");
            _container = new PerRequestUnityContainer(container);
        }
        /// <summary>
        /// Releases the specified controller.
        /// </summary>
        /// <param name="controller">The controller to release.</param>
        public override void ReleaseController(IController controller)
        {
            if (controller != null)
            {
                _container.Teardown(controller);
            }
            base.ReleaseController(controller);
        }
    }
    public class UnityControllerActivator : IControllerActivator
    {
        private readonly IUnityContainer _container;
        public UnityControllerActivator(IUnityContainer container)
        {
            ////Guard.ArgumentNotNull(container, "container");
            _container = new PerRequestUnityContainer(container);
        }
        /// <summary>
        /// When implemented in a class, creates a controller.
        /// </summary>
        /// <returns>
        /// The created controller.
        /// </returns>
        /// <param name="requestContext">The request context.</param><param name="controllerType">The controller type.</param>
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            ////Guard.ArgumentNotNull(requestContext, "requestContext");
            ////Guard.ArgumentNotNull(controllerType, "controllerType");
            // do what ever you need to before creating your controller
            IController controller = (IController)_container.Resolve(controllerType);
            return controller;
        }
    }
