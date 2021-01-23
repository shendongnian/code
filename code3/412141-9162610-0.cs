        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = null;
            if (controllerType == null)
            {
                throw new HttpException(404, String.Format("The controller for path '{0}' could not be found or it does not implement IController.", requestContext.HttpContext.Request.Path));
            }
            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException(String.Format("Type requested is not a controller: {0}", controllerType.Name), "controllerType");
            }
            try
            {
                if (this.container.IsRegistered(controllerType))
                {
                    controller = this.container.Resolve(controllerType) as IController;
                }
                else
                {
                    controller = base.GetControllerInstance(requestContext, controllerType);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format("Error resolving controller {0}", controllerType.Name, ex));
            }
            return controller;
        }
