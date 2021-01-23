     class CollectionOwner<T,TGenericCollection>
               where TGenericCollection : IGenericCollection<T>
            {
                protected TGenericCollection theCollection = default(TGenericCollection);
            }
