    public IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
    {
        List<T> objects = new List<T>();
        foreach (Type type in typeof(T).GetTypeInfo().Assembly.ExportedTypes
                                       .Where(myType => myType.GetTypeInfo().IsClass && 
                                                        !myType.GetTypeInfo().IsAbstract && 
                                                        myType.GetTypeInfo().IsSubclassOf(typeof(T))))
        {
            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
        }
        objects.Sort();
        return objects;
    }
