    public ITemplate Resolve(string cacheName, object model)
    {
        CachedTemplateItem cachedItem;
        ITemplate instance = null;
        if (_cache.TryGetValue(cacheName, out cachedItem))
            instance = CreateTemplate(null, cachedItem.TemplateType, model);
        if (instance == null && _config.Resolver != null)
        {
            string template = _config.Resolver.Resolve(cacheName);
            if (!string.IsNullOrWhiteSpace(template))
                instance = GetTemplate(template, model, cacheName);
        }
        return instance;
    }
