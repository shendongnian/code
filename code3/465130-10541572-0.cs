    public Type GetPageTypeByURL(string url)
    {
        object page = BuildManager.CreateInstanceFromVirtualPath(url, typeof(object));
        return page.GetType().BaseType.BaseType;
    }
