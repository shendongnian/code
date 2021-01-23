    public class ModuleA : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        public ModuleA(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion",
                () => _container.Resolve<NameOfYourView>());
        }
    }
