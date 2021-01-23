    var cssBundle = new StyleBundle("~/bundle/css");
    cssBundle.Include(config.Source);
    
    // if your bundle is already in BundleTable.Bundles list, use that.  Otherwise...
    var collection = new BundleCollection();
    collection.Add(cssBundle)
    
    // get bundle contents
    var resolver = new BundleResolver(collection);
    List<string> cont = resolver.GetBundleContents("~/bundle/css").ToList();
