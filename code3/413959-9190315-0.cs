    public class MyModule : IModule
    {
      private readonly IUnityContainer container;
      public MyModule(IUnityContainer container)
      {
        this.container = container;
      }
      public void Initialize()
      {
        this.container.Register<IFactory, MyFactory>("MyFactory");
      }
    }
    
    public class Shell
    {
      public Shell(IFactory[] factories)
      {
        // work with factories
      }
    }
