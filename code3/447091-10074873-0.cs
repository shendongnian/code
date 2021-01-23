    public Expression<Func<T, To>> SortingFactory<T, To>( String sortby )
    {
        // Entity type
        System.Type dataType = typeof( T );
    
        // Entity - main parameter (x =>
        ParameterExpression rootExp = Expression.Parameter(dataType, "x" );
        // property (x => x.Property
        PropertyInfo pi = dataType.GetProperty( sortby );
        // put together
        Expression expr = Expression.Property( rootExp, pi );
        return Expression.Lambda<Func<T, To>>( expr, rootExp );
    }
