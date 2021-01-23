    public partial class HashDictionary<T> : Dictionary<T, T>
    {
        public T GetOrAdd(T newItem)
        {
            T oldItem;
            if (this.TryGetValue(newItem, out oldItem))
                return oldItem;
            this.Add(newItem, newItem);
            return newItem;
        }
    }        
