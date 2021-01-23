    class CollectionOwner<TGenericCollection, T2>
       where TGenericCollection : IGenericCollection<T2>
       where T2 : class
    {
        protected TGenericCollection theCollection = default(TGenericCollection);
    }
