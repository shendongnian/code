    public static Type[] GetTypesLoaded(Assembly assembly)
    {
        Type[] types;
        try
        {
          types = assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
          types = e.Types.Where(t => t != null).ToArray();
        }
    
        return types;    
    }
