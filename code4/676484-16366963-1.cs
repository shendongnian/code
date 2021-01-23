    public IEnumerable<T> FilterMe(IEnumerable<IFilterable> linked)
    {
        var dict = GetDict();
        return linked.Where(r => dict.ContainsKey(r.Id)).Cast<T>();
    }
