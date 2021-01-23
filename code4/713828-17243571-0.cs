    using System.Linq.Expressions;
    public static Expression<Func<TEntity, bool>> DefaultFilter<TEntity>()
        where TEntity : IEntity
    {
       if (typeof(SoftDeleteEntity).IsAssignableFrom(typeof(TEntity)))
          return DefaultFilterSoftDelete<TEntity>();
       else return x => true;
    }
    
    public static Expression<Func<TEntity, bool>> DefaultFilterSoftDelete<TEntity>()
        where TEntity : IEntity
    {
        var parameterExpression = Expression.Parameter(typeof(TEntity));
    	var propertyExpression = Expression.Property(parameterExpression,
            "IsDeleted");
    	var notExpression = Expression.Not(propertyExpression);
        var lambdaExpression = Expression.Lambda<Func<TEntity, bool>>(notExpression,
            parameterExpression);
    	
        return lambdaExpression;
    }
