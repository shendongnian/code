    public MyMainPluginClass() : this(FactoryUtility.SetupIOC())
    {
     
    }
    public MyMainPluginClass(IRepo repo)
    {
    }
    public static class FactoryUtility
    {
        private static bool Initialized  = false;
        public static IRepo SetupIOC()
        {
            var container = TinyIoCContainer.Current;
            if (!Initialized)
            {
                container.AutoRegister(new[] { Assembly.GetExecutingAssembly() });
                Initialized = true;
            }
            var result = container.Resolve<IRepo>();
            return result;
        }
    }
