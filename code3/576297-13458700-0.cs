    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle scriptBundle = new ScriptBundle("~/js");
            string[] scriptArray =
            {
                "~/content/plugins/jquery/jquery-1.8.2.js",
                "~/content/plugins/jquery/jquery-ui-1.9.0.js",
                "~/content/plugins/jquery/jquery.validate.js",
                "~/content/plugins/jquery/jquery.validate.unobtrusive.js",
                "~/content/plugins/bootstrap/js/bootstrap.js",
            };
            scriptBundle.Include(scriptArray);
            scriptBundle.IncludeDirectory("~/content/js", "*.js");
            bundles.Add(scriptBundle);
        }
    }
