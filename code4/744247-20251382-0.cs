        public static IEnumerable<object> FindViews(this IRegion region, string viewName)
        {
            return from view in region.Views
                   from attr in Attribute.GetCustomAttributes(view.GetType())
                   where attr is ViewExportAttribute && ((ViewExportAttribute)attr).ViewName == viewName
                   select view;
        }
        public static void ActivateOrRequestNavigate(this IRegionManager regionManager, string regionName, string viewName, UriQuery navigationParams)
        {
            IRegion region = regionManager.Regions[regionName];
            object view = region.FindViews(viewName).FirstOrDefault();
            if (view != null)
                region.Activate(view);
            else
                regionManager.RequestNavigate(regionName,
                    new System.Uri(navigationParams != null ? viewName + navigationParams.ToString() : viewName, UriKind.Relative));
        }
        public static void RemoveAndRequestNavigate(this IRegionManager regionManager, string regionName, string viewName, UriQuery navigationParams)
        {
            IRegion region = regionManager.Regions[regionName];
            foreach (object view in region.FindViews(viewName))
                region.Remove(view);
            regionManager.RequestNavigate(regionName,
                    new System.Uri(navigationParams != null ? viewName + navigationParams.ToString() : viewName, UriKind.Relative));
        }
