    public void DynamicMap<TSource, TDestination>(TSource source, TDestination destination)
    {
        Type modelType = typeof(TSource);
        Type destinationType = (Equals(destination, default(TDestination)) ? typeof(TDestination) : destination.GetType());
        DynamicMap(source, destination, modelType, destinationType);
    }
