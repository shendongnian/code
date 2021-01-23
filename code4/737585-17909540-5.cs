    private class SomeServiceFactory : ISomeServiceFactory
    {
        private readonly Container container;
        // Here we depend on Container, which is fine, since
        // we're inside the composition root. The rest of the
        // application knows nothing about a DI framework.
        public SomeServiceFactory(Container container)
        {
            this.container = container;
        }
        public ISomeService Create(int inputParameter)
        {
            // Do what ever we need to do here. For instance:
            if (inputParameter == 0)
                return this.container.GetInstance<Service1>();
            else
                return this.container.GetInstance<Service2>();
        }
    }
    public static void Initialize()
    {
        var container = new Container();
        container.RegisterSingle<ISomeServiceFactory, SomeServiceFactory>();
    }
