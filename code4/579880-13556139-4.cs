        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.regionManager.RequestNavigate(RegionNames.TabControlRegion, new Uri(ViewNames.HomeTabItemView, UriKind.Relative));
            this.regionManager.RequestNavigate(RegionNames.TabControlRegion, new Uri(ViewNames.SpritsTabItemView, UriKind.Relative));
        }
