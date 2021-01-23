    public IQueryable<TE, TKey> SelectAll(Expression<Func<TE, bool>> predicate, 
                Expression<Func<TE, TKey>> sortExpression, bool orderDescending = false)
    {
        var list = _ctx.CreateQuery<TE>("[" + typeof(TE).Name + "]")
                       .AsExpandable().Where(predicate);
    
        return orderDescending 
            ? list.OrderByDescending(sortExpression) 
            : list.OrderBy(sortExpression);
    }
