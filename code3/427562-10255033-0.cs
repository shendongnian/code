    private void BootStrapWindsorContainer()
    {
         _container = new WindsorContainer()
              .Install(FromAssembly.This());
         var controllerFactory = new WindsorControllerFactory(_container.Kernel);
         ControllerBuilder.Current.SetControllerFactory(controllerFactory);
         ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(_container));
         GlobalConfiguration.Configuration.ServiceResolver.SetResolver(
             t =>
                 {
                     try
                    {
                        return _container.Resolve(t);
                    }
                    catch
                    {
                        return null;
                    }
                },
                t =>
                {
                    try
                    {
                        return _container.ResolveAll(t).OfType<object>();
                    }
                    catch
                    {
                 return new List<object>();
             }
        });
    }
