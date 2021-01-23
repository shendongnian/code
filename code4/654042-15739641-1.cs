    public void DynamicMap<TSource, TDestination>(TSource source, TDestination destination)
    {
        Type modelType = typeof(TSource);
        Type destinationType = typeof(TDestination);
        DynamicMap(source, destination, modelType, destinationType);
    }
