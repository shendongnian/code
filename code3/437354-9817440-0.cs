    public void Register(string name, Type service, Type impl)
    {
       WindsorContainer container = new WindsorContainer();
       IKernel kernel = container.Kernel;
       kernel.AddComponent(name, service, impl, LifestyleType.Singleton);
    }
