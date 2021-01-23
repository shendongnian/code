    // We want Enumerable.Any<T>(IEnumerable<T>,Predicate<T>)
    var overload = typeof(Enumerable).GetMethods("Any")
                                     .Single(mi => mi.GetParameters().Count() == 2);
    var call = Expression.Call(
        overload,
        Expression.PropertyOrField(projParam, "GroupsAssigned"),
        anyLambda);      
