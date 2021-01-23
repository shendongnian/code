    using SimpleInjector;
    public static class BootstrapperModule
    {
        public static void Register(Container container)
        {
            container.RegisterSingle<IBar, Bar>();
            container.RegisterSingle<IFoo, Foo>();            
        }
    }
