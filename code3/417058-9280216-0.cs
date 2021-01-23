    public MyMainPluginClass() : this(FactoryUtility.SetupIOC())
    {
     
    }
    public MyMainPluginClass(IRepo repo)
    {
    }
    public static class FactoryUtility
    {
         public static IRepo SetupIOC()
        {
            var container = TinyIoCContainer.Current;
            container.AutoRegister(new[] { Assembly.GetExecutingAssembly() });
            var result = container.Resolve<IRepo>();
            return result;
        }
    }
