    static Expression BuildAny<TSource>(Expression<Func<TSource, bool>> predicate)
    {
        var overload = typeof(Queryable).GetMethods("Any")
                                  .Single(mi => mi.GetParameters().Count() == 2);
        var call = Expression.Call(
            overload,
            Expression.PropertyOrField(projParam, "GroupsAssigned"),
            predicate);   
        return call;
    }
