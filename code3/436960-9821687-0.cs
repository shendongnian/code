    public void Main(params string[] args)
    {
        using (var container = new Container())
        {
            container.LoadAllConfigurationModules();
            container.AddRegistry<SomeRegistry>();
            container.GetInstance<Application>().Run(args);
        }
    }
