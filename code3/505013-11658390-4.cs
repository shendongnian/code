    public static class MyStyleHelper {    
       public static IHtmlString RenderViewSpecificStyle(IView view)
        {
            var viewName = GerViewName(view);
            var bundleName = EnsureBundle(viewName);
            return Styles.Render(bundleName);
        }
    
        public static string GerViewName(IView view)
        {
            var webFormView = view as WebFormView;
            if (webFormView == null)
            {
                throw (new ArgumentException("WebFormView is expected."));
            }
    
            string viewUrl = webFormView.ViewPath;
            string viewFileName = viewUrl.Substring(viewUrl.LastIndexOf('/'));
            string viewFileNameWithoutExtension = Path.GetFileNameWithoutExtension(viewFileName);
            return viewFileNameWithoutExtension;
        }
    
        public static string EnsureBundle(string viewName)
        {
            var bundleName = "~styles/" + viewName;
            var bundle = BundleTable.Bundles.GetBundleFor(bundleName);
            if (bundle == null)
            {
                bundle = new StyleBundle(bundleName).Include(
                    "~/styles/site.css",
                    "~/styles/" + viewName + ".css");
                BundleTable.Bundles.Add(bundle);
            }
            return bundleName;
        }
    }
