    public void FillCache<cachedModelItem>(ICachedModel model, int CachedEntitiesID)
            where cachedModelItem: ICachedModelItem, new()
    {
        foreach (ICachedModelItem item in model.Items)
        {
            string foo = item.foo.ToString();
        }
    }
