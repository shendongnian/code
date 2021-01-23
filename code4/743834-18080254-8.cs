    using System.Data.Entity; // For the Include extension method.
    private void LoadRelatedData<TEntity, TRelated>(TEntity entity, Expression<Func<TEntity, ICollection<TRelated>> navigationProperty)
        where TEntity : class
        where TRelated : class
    {
        if (!ConxCore.Instance.EntityModel.Entry(entity).Collection(navigationProperty).IsLoaded) 
        {
            var list = ConxCore.Instance.EntityModel.Set<TEntity>().Include(navigationProperty).ToList();
        }
    }
