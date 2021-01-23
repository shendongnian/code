    public IEnumerable<T> IterateWhere(IEnumerable<T> source, Funct<T,bool> predicate)
    {
        foreach (var element in source)
        {
            if (predicate(element))
            {
                yield return element;
            }
        }
    }
