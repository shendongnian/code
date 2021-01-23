    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.UseCdn = true;
      var jqueryCdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.3.min.js";
      var jqueryBundle = new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include("~/Scripts/jquery-{version}.min.js");
      jqueryBundle.CdnFallbackExpression = "window.jQuery";
      bundles.Add(jqueryBundle);
      // ...
      BundleTable.EnableOptimizations = true;
    }
