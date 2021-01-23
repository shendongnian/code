    IEnumerable<Type> FindTypesInAssemblyImplementingMyInterface<T>(string path_)
    {
        Assembly assembly = Assembly.LoadFrom(path);
        foreach (Type t in assembly.GetTypes())
        {
            if (typeof(IMyInterface).IsAssignableFrom(t))
            {
                yield return t;
            }
        }
    }
