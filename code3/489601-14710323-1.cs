    public class EntityCollection<T> : Collection<T>
    {
        [Obsolete("Unboxing this collection is only allowed in the declarating class.", true)]
        public new void Add(T item) { }
        [Obsolete("Unboxing this collection is only allowed in the declarating class.", true)]
        public new void Clear() { }
        [Obsolete("Unboxing this collection is only allowed in the declarating class.", true)]
        public new void Insert(int index, T item) { }
        [Obsolete("Unboxing this collection is only allowed in the declarating class.", true)]
        public new void Remove(T item) { }
        [Obsolete("Unboxing this collection is only allowed in the declarating class.", true)]
        public new void RemoveAt(int index) { }
        public static implicit operator EntityCollection<T>(List<T> source)
        {
            var target = new EntityCollection<T>();
            foreach (var item in source)
                ((Collection<T>) target).Add(item); // unbox
            return target;
        }
    }
