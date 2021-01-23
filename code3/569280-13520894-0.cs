    interface IConfiguration
    {
      string ConnectionString { get; }
      int MaxLevels { get; }
    }
    
    class Configuration: IConfiguration
    {
      string ConnectionString { get { return "BlahBlah"; } }
      int MaxLevels { get { return 123; } }
    }
    
    myUnityContainer.RegisterType<IConfiguration, Configuration>(new ContainerControlledLifetimeManager();
    class YourClass
    {
      public YourClass(IConfiguration configuration)
      {
        // Use settings from "configuration"
      }
    }
