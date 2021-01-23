    public class EnhancedGenericBagType<T> : BagType
        {
            public EnhancedGenericBagType(string role, string propertyRef) :
                base(role, propertyRef, false) { }
    
            public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
            {
                return new EnhancedPersistentGenericBag<T>(session);
            }
    
            public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
            {
                return new EnhancedPersistentGenericBag<T>(session, (ICollection<T>)collection);
            }
    
            public override Type ReturnedClass
            {
                get
                {
                    return typeof(ICollection<T>);
                }
            }
    
            protected override void Add(object collection, object element)
            {
                ((ICollection<T>)collection).Add((T)element);
            }
    
            protected override void Clear(object collection)
            {
                ((ICollection<T>)collection).Clear();
            }
    
            public override object Instantiate(int anticipatedSize)
            {
                if (anticipatedSize > 0)
                    return new List<T>(anticipatedSize + 1);
                else
                    return new List<T>();
            }
        }
