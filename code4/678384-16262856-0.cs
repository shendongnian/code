    public IEnumerable<TResult> FilterwithinOrg<TResult>(IEnumerable<TResult> linked) where TResult :  IFilterable
    {
        var dict = GetDict();
        return linked.Where(r => dict.ContainsKey(r.Id));
    }
