    public static IPublishedContent GetRootNode()
    {
        var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        var rootNode = umbracoHelper.TypedContentSingleAtXPath("//root"));
    
        return rootNode;
    }
