    public ShellView(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
    {
    }
    
    public class IModule1 : IModule
    {
      public void Initialize()
      {
         var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
         var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
         regionManager.RegisterViewWithRegion("Region1", typeof(Module1View));   
    
      }
    }
    
    public class IModule2 : IModule
    {
      public void Initialize()
      {
         var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
        var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
         regionManager.RegisterViewWithRegion("Region2", typeof(Module2View));   
    
      }
    }
