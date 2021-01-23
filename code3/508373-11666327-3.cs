            _container.RegisterType<ITiersView, Tiers>();
            _container.RegisterType<ITiersViewModel, TiersViewModel>();
            IRegion Content = _regionManager.Regions[RegionNames.ContentRegion];
            var TiersView = _container.Resolve<ITiersView>();
            RibbonRegion.Add(TiersView);
