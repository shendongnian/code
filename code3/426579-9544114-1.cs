            protected void Application_Start()
            {
                // code intentionally omitted
    
                IUnityContainer container = BuildUnityContainer();
                container.RegisterInstance<System.Web.Http.Dispatcher.IHttpControllerActivator>(new UnityHttpControllerActivator(container));
    
                System.Web.Http.GlobalConfiguration.Configuration.ServiceResolver.SetResolver(
                   t =>
                   {
                     // rest of code is the same and is omitted.
  
