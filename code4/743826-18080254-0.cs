    private void LoadRelatedData<T, TRelated>(T obj, Expression<Func<T, ICollection<TRelated>> relatedCollectionGetter)
    {
        if (!ConxCore.Instance.EntityModel.Entry(obj).Collection(relatedCollectionGetter).IsLoaded) 
        {
            var list = ConxCore.Instance.EntityModel.Set<T>().SelectMany(relatedCollectionGetter).ToList();
        }
    }
