    public override string GetOutputCacheProviderName(HttpContext context)
    {
        string absolutePath = context.Request.Url.AbsolutePath;
        if (absolutePath.StartsWith("/Content/", StringComparison.CurrentCultureIgnoreCase)
            || absolutePath.StartsWith("/Scripts/", StringComparison.CurrentCultureIgnoreCase)
            || absolutePath.StartsWith("/Images/", StringComparison.CurrentCultureIgnoreCase))
            return base.GetOutputCacheProviderName(context);
        return "CustomOutputCacheProvider";
    }
