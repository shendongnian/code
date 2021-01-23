    IEnumerable<Type> FindTypesInAssemblyImplementingMyInterface<T>(Assembly assembly_)
    {
        foreach (Type t in assembly_.GetTypes())
        {
            if (typeof(T).IsAssignableFrom(t))
            {
                yield return t;
            }
        }
    }
