    public class WindsorHttpControllerFactory : IHttpControllerFactory
    {
        private readonly IKernel kernel;
        private readonly HttpConfiguration configuration;
        public WindsorHttpControllerFactory(IKernel kernel, HttpConfiguration configuration)
        {
            this.kernel = kernel;
            this.configuration = configuration;
        }
        public IHttpController CreateController(HttpControllerContext controllerContext, string controllerName)
        {
            if (controllerName == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", controllerContext.Request.RequestUri.AbsolutePath));
            }
            var controller = kernel.Resolve<IHttpController>(controllerName);
            controllerContext.Controller = controller;
            controllerContext.ControllerDescriptor = new HttpControllerDescriptor(configuration, controllerName, controller.GetType());
            
            return controllerContext.Controller;
        }
        public void ReleaseController(IHttpController controller)
        {
            kernel.ReleaseComponent(controller);
        }
    }
