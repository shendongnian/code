    private void LoadRelatedDataOfSingleObject<TEntity, TRelated>(TEntity entity, Expression<Func<TEntity, ICollection<TRelated>> navigationProperty)
        where TEntity : class
        where TRelated : class
    {
        var collectionEntry = ConxCore.Instance.EntityModel.Entry(entity).Collection(navigationProperty);
        if (!collectionEntry.IsLoaded) collectionEntry.Load();
    }
