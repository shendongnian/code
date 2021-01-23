    protected void Application_Start()
    {
        // code intentionally omitted
        IUnityContainer container = BuildUnityContainer();
        container.RegisterInstance<IHttpControllerActivator>(new UnityHttpControllerActivator(container));
        ServiceResolver.SetResolver(t =>
           {
             // rest of code is the same as in question above, and is omitted.
           });
    }
