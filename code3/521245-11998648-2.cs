    public class MyKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
    {
        public MyKeyedCollection(String keyProperty)
        {
            _keyProperty = keyProperty;
        }
    
        private String _keyProperty;
    
        protected override TKey GetKeyForItem(TItem item)
        {
            return (TKey)item.GetType().GetProperty(_keyProperty).GetValue(item, null);
        }
    }
