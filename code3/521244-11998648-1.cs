    public class MyKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
    {
        public MyKeyedCollection(Func<TItem, TKey> keyFunction)
        {
            _keyFunction = keyFunction;
        }
        private Func<TItem, TKey> _keyFunction;
        protected override TKey GetKeyForItem(TItem item)
        {
            return _keyFunction(item);
        }
    }
