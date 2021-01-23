    IEnumerable<Type> FindTypesInAssemblyImplementingMyInterface<T>(string path_)
    {
        Assembly assembly = Assembly.LoadFrom(path);
        foreach (Type t in assembly.GetTypes())
        {
            if (typeof(T).IsAssignableFrom(t))
            {
                yield return t;
            }
        }
    }
