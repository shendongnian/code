    @{
      var bundle = Microsoft.Web.Optimization.BundleTable.Bundles.GetRegisteredBundles()
        .Where(b => b.TransformType == typeof(Microsoft.Web.Optimization.JsMinify))
        .First();
    
      bundle.AddFile("~/Scripts/DatePicker.js");
    }
