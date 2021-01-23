    public static S Generize<S, T>(this S source, T dummyVariable) 
                                  where S : class, IEnumerable<T>
    {
        var lst = source.ToList();
        lst.Add(dummyVariable);
        if (source is T[])
            return lst.ToArray() as S;
        if (source is List<T>)
            return lst as S;
        if (source is Collection<T>)
            return new Collection<T>(lst) as S;
        throw new TypeAccessException();
    }
