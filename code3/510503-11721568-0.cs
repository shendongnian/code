    public static Expression<Func<T, bool>> CreatePredicate<T>(string typeSearch, string searchField, string stringToSearch)
    {
        var parameter = Expression.Parameter(typeof(T));
        var predicate = Expression.Lambda<Func<T, bool>>(
            Expression.Call(
                Expression.Call(Expression.PropertyOrField(parameter, searchField), "ToUpper", null),
                "Contains", null,
                Expression.Constant(stringToSearch.ToUpper())), parameter);
        return predicate;
    }
