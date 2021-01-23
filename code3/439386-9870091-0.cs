    public static IQueryable<TSource> FilterConfirmable<TSource>(this IQueryable<TSource> source, ConfirmableFilter Confirmablefilter, [Optional, DefaultParameterValue("Confirmed")] string fieldName)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }
        if (Confirmablefilter == ConfirmableFilter.All)
        {
            return source;
        }
        Type sourceType = typeof(TSource);
        PropertyInfo confirmedProperty = sourceType.GetProperty(fieldName);
        if (confirmedProperty == null)
        {
            throw new InvalidOperationException(string.Format("Can not find a boolean column named \"{0}\", Consider to add a column named \"{0}\" in your linq select expression.", fieldName));
        }
        ParameterExpression o = Expression.Parameter(sourceType, "o");
        Expression equal = Expression.Equal(Expression.Property(o, confirmedProperty), Expression.Constant(Confirmablefilter == ConfirmableFilter.Confirmed));
        MethodCallExpression whereCallExpression = Expression.Call(typeof(Queryable), "Where", new Type[] { sourceType }, new Expression[] { source.Expression, Expression.Lambda<Func<TSource, bool>>(equal, new ParameterExpression[] { o }) });
        return source.Provider.CreateQuery<TSource>(whereCallExpression);
    }
 
