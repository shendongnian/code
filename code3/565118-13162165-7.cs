        [ContractClassFor(typeof(ICollectionViewFilter<>))]
        public abstract class CollectionViewFilterContracts<T> : ICollectionViewFilter<T> where T : class
        {
            public bool FilterObject(T obj)
            {
                Contract.Requires<ArgumentNullException>(obj != null, "Filtered object can't be null");
    
                return default(bool);
            }
        }
