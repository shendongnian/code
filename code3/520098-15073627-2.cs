    using System;
    using System.Web.Optimization;
    using StyleBundle = MyNamespace.CustomStyleBundle;
    
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/themes/base/css")
                .IncludeDirectory("~/Content/themes/base", "*.css"));
        }
    }
