    public class Sort2<T> : ObservableCollection<T>
    {
        Type keyType;
        object key1;
        public void Sort<TKey>(Func<T, TKey> selector, int skip = 0)
        {
            //...
        }
        public void SetKey<TKey>(TKey val)
        {
            keyType = typeof(TKey);
            key1 = val;
        }
        public TKey GetKey<TKey>()
        {
            return (TKey)key1;
        }
        public Type GetKeyType()
        {
            return keyType;
        }
    }
