    public static Expression<Func<TEntity, bool>> GetPredicate<TDto, TEntity>(
        TDto dto)
    {
        var entityParameter = Expression.Parameter(typeof(TEntity), "x");
        var dtoProperties = typeof(TDto).GetProperties();
        var entityProperties = typeof(TEntity).GetProperties();
        ExpressionScope<TDto> scope = new ExpressionScope<TDto>()
        {
            Value = dto
        };
        var dtoMemberAccess = Expression.MakeMemberAccess(
            Expression.Constant(scope),
            typeof(ExpressionScope<TDto>).GetProperty("Value"));
        var equalityExpressions = dtoProperties.Select(x => Expression.Equal(
            Expression.Property(
                entityParameter,
                entityProperties.FirstOrDefault(y => y.Name == x.Name)),
            Expression.Property(dtoMemberAccess, x)));
        var aggregateEquality = equalityExpressions.Aggregate(
            (x, y) => Expression.AndAlso(x, y));
        var predicate = Expression.Lambda<Func<TEntity, bool>>(
            aggregateEquality, entityParameter);
        return predicate;
    }
    private class ExpressionScope<TDto>
    {
        public TDto Value { get; set; }
    }
