    private IQueryable<ResultObject> GenerateOrClause(IQueryable<ResultObject> query,
                                                      IList<Conditions> conditions)
    {
        if( conditions.Count == 0 )
            return query;
        
        var pe = Expression.Parameter(typeof(ResultObject), "c");
        Expression builder = GetProperty(pe, conditions.First());
        
        foreach(var condition in conditions.Skip(1))
        {
            var property = GetProperty(pe, condition);
            builder = Expression.OrElse(builder, property);
        }
        
        var predicate = Expression.Lambda(builder, pe);
        
        return query.Where((Func<ResultObject, bool>)predicate.Compile()).AsQueryable();
    }
    
    private static MemberExpression GetProperty(ParameterExpression pe,
                                                Conditions condition)
    {
        MemberExpression property;
    
        switch (condition)
        {
            case Conditions.ByAlpha:
                property = Expression.Property(pe, "AlphaValue");
                break;
            case Conditions.ByBeta:
                property = Expression.Property(pe, "BetaValue");
                break;
            case Conditions.ByGamma:
                property = Expression.Property(pe, "GammaValue");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        return property;
    }
