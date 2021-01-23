     public class TiersModuleInit : IModule
        {
            IUnityContainer _container;
            IRegionManager _RegionManager;
    
            /// <summary>
            /// Initializes a new instance of the TiersModuleInit class.
            /// </summary>
            /// <param name="unityContainer"></param>
            /// <param name="regionManager"></param>
            public TiersModuleInit(IUnityContainer unityContainer, IRegionManager regionManager)
            {
                _container = unityContainer;
                _RegionManager = regionManager;
            }
    
            public void Initialize()
            {
                 
                _container.RegisterType<ITiersTabView, TiersTab>();
                _container.RegisterType<ITiersTabViewModel, TiersTabViewModel>();
                IRegion RibbonRegion = _RegionManager.Regions[RegionNames.RibbonRegion];
                var TiersTab = _container.Resolve<ITiersTabView>();
                RibbonRegion.Add(TiersTab);
            }
        }
