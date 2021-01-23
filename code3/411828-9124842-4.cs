    public ResolveAllDemo() 
    {
      var container = new UnityContainer();
      container.RegisterType<IParser, SuperParser>("SuperParser");
      container.RegisterType<IParser, DefaultParser>("DefaultParser");
      container.RegisterType<IParser, BasicParser>("BasicParser");
      container.RegisterType<IParserFactory, UnityParserFactory>();
      foreach (var registeredMember in container.ResolveAll<IParser>())
      {
         LoggingUtility.LogerInstance.Logger.Write(registeredMember);
      }
    }
