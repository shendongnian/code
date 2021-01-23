    public IOrderedQueryable<Something> SortRank(IQueryable<Something> query, Sort sort)
    {
        Expression<Func<Something, DateTime>> sortExpression = t => t.Date;
        if (sort == Sort.Newest)
        {
            return query.OrderByDescending(sortExpression);
        }
        else
        {
            return query.OrderBy(sortExpression);
        }
    }
