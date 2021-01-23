    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ...
    
            bundles.Add(new StyleBundle("~page1").Include(
                 "~/Styles/site.css",
                 "~/Styles/page1.css"));
    
            bundles.Add(new StyleBundle("~page2").Include(
                 "~/Styles/site.css",
                 "~/Styles/page2.css"));
    
            ...
    
            bundles.Add(new StyleBundle("~pageN").Include(
                 "~/Styles/site.css",
                 "~/Styles/pageN.css"));
    
        }
    }
