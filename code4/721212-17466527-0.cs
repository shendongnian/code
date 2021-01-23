    List<string> resourceNames = new List<string>();
    var assembly = Assembly.GetExecutingAssembly();
    var rm = new ResourceManager(assembly.GetName().Name + ".g", assembly);
    try
    {
        var list = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true);
        foreach (DictionaryEntry item in list)
            resourceNames.Add((string)item.Key);
    }
    finally
    {
        rm.ReleaseAllResources();
    }
