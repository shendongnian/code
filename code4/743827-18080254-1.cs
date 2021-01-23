    private void LoadRelatedDataOfSingleObject<T, TRelated>(T obj, Expression<Func<T, ICollection<TRelated>> relatedCollectionGetter)
    {
        var collectionEntry = ConxCore.Instance.EntityModel.Entry(obj).Collection(relatedCollectionGetter);
        if (!collectionEntry.IsLoaded) collectionEntry.Load();
    }
