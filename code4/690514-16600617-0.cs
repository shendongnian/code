    List<SiteNode> siteNodes;
    object cached_site_nodes = _cacheManager.Get(Constants.CacheKeys.SiteNodesCacheKey);
    if (null != cached_site_nodes)
    {
       siteNodes = (List<SiteNode)cached_site_nodes;
    }
    else
    {
       siteNodes = new List<SiteNode>();
    }
