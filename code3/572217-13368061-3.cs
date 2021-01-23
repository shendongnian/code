    public static S Generize<S, T>(this S source, T dummyVariable) 
                                  where S : class, IEnumerable<T>
    {
        var lst = source.ToList();
        lst.Add(dummyVariable);
        if (source is Array)
            return lst.ToArray() as S;
        foreach (var c in typeof(S).GetConstructors())
        {
            var p = c.GetParameters();
            if (p.Length != 1)
                continue;
            if (typeof(IEnumerable<T>).IsAssignableFrom(p[0].ParameterType))
                return Activator.CreateInstance(typeof(S), lst) as S;
        }
        throw new TypeAccessException();
    }
