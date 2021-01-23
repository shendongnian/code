    public IQueryable<TResult> FilterwithinOrg<TResult>(IQueryable<TResult> linked) where TResult :  IFilterable
    {
        var dictKeys = GetDict().Keys.ToList();
        return linked.Where(r => dictKeys.Contains(r.Id));
    }
