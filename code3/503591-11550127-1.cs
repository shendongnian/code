    IVsHierarchy hier = VsHelper.ToHierarchy(dteProject);
    DynamicTypeService typeService = (DynamicTypeService)this.GetService(typeof(DynamicTypeService));
    ITypeDiscoveryService discovery = typeService.GetTypeDiscoveryService(hier);
    try
    {
        foreach (Type type in discovery.GetTypes(typeof(object), true))
        {
            if (!availableTypes.ContainsKey(type.FullName))
            {
                availableTypes.Add(type.FullName, type);
            }
            if (!availableAssemblies.ContainsKey(type.Assembly.GetName().Name))
            {
                availableAssemblies.Add(type.Assembly.GetName().FullName, type.Assembly);
            }
        }
    }
    catch (Exception e)
    {
    }
