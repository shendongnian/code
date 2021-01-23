    [ContractClass(typeof(CollectionViewFilterContracts<>))]
    public interface ICollectionViewFilter<in T> where T : class
    {
        bool FilterObject(T obj);
    }
