    public class EnhancedPersistentGenericBag<T> : PersistentGenericBag<T> , ITypedList
    {
            public EnhancedPersistentGenericBag(ISessionImplementor session, ICollection<T> coll) : base(session, coll) { }
    
            public EnhancedPersistentGenericBag(ISessionImplementor session) : base(session) { }
    
            public EnhancedPersistentGenericBag() { }
    
            public new T this[int index]
            {
                get
                {
                    return (T)base[index];
                }
                set
                {
                    base[index] = value;
                }
            }
    
            public string GetListName(PropertyDescriptor[] listAccessors) { return GetType().Name; }
    
            public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
            {
                return TypeDescriptor.GetProperties(typeof(T));
            }
        }
