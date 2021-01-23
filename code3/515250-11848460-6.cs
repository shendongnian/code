    public static T LoadPluginByPathName<T>(string pathName)
    {
        string viewType = typeof(T).GUID.ToString();
        if (HttpRuntime.Cache[viewType] != null)
            return HttpRuntime.Cache[viewType] is T ? (T)HttpRuntime.Cache[viewType] : default(T);
        object plugin = Assembly.LoadFrom(pathName);
        if (plugin != null)
        {
            //Cache this object as we want to only load this assembly into memory once.
            HttpRuntime.Cache.Insert(viewType, plugin);
            return (T)plugin;
        }
        return default(T);
    }
