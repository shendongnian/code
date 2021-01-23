    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new StyleBundle("/~Content/css").
        Include(String.Format("~/Content/{0}/site.css",
        ConfigurationManager.AppSettings("theme"))));
    }
