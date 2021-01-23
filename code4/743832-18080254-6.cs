    private void LoadRelatedData<TEntity, TRelated>(TEntity entity, Expression<Func<TEntity, ICollection<TRelated>> navigationProperty)
        where TEntity : class
        where TRelated : class
    {
        if (!ConxCore.Instance.EntityModel.Entry(entity).Collection(navigationProperty).IsLoaded) 
        {
            var rewrittenLambda = Expression.Lambda<Func<TEntity, IEnumerable<TRelated>>>(navigationProperty.Body, navigationProperty.Parameters);
            var list = ConxCore.Instance.EntityModel.Set<TEntity>().SelectMany(rewrittenLambda).ToList();
        }
    }
