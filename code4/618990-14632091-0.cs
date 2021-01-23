    RenderingReference[] renderings = Sitecore.Context.Item.Visualization.GetRenderings(Sitecore.Context.Device, true);
    foreach (var renderingReference in renderings)
    {
        // var isDefinitionItemCacheable = renderingReference.RenderingItem.Caching.Cacheable;
        var isInstanceCacheable = renderingReference.Settings.Caching.Cacheable;
    }
