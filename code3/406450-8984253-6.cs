    public static class BootstrapperPackage
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IBar, Bar>(Lifestyle.Scoped);
            container.Register<IFoo, Foo>(Lifestyle.Singleton);            
        }
    }
