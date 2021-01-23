        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, new Uri(ViewNames.HomeTabItemView, UriKind.Relative));
            regionManager.RequestNavigate(RegionNames.ContentRegion, new Uri(ViewNames.SpritsTabItemView, UriKind.Relative));
        }
