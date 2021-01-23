    public class BundleConfig
    {
                // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/all").Include(
                "~/Scripts/modernizr-*",
                 "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.unobtrusive*",        
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/custom-ie-enhancements.js"));
         
            BundleTable.EnableOptimizations = true;
        }
    }
}
