    public interface IControllerActivator
    {
        /// <summary>
        /// When implemented in a class, creates a controller.
        /// </summary>
        IController Create(RequestContext requestContext, Type controllerType);
    }
