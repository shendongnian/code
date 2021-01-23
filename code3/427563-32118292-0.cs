    public class WindsorHttpControllerFactory : IHttpControllerActivator
        {
            readonly IWindsorContainer _container;
    
            public WindsorHttpControllerFactory(IWindsorContainer container)
            {
                _container = container;
            }
    
            public IHttpController Create(HttpRequestMessage request,
                                          HttpControllerDescriptor controllerDescriptor,
                                          Type controllerType)
            {
                var controller = (IHttpController)_container.Resolve(controllerType);
    
                request.RegisterForDispose(new Release(() => _container.Release(controller)));
                return controller;
            }
    
            class Release : IDisposable
            {
                readonly Action _release;
    
                public Release(Action release)
                {
                    _release = release;
                }
    
                public void Dispose()
                {
                    _release();
                }
            }
        }
