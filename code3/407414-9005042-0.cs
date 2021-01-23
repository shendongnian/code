    public class SortedKeydCollection<TKey, TOrder, TValue> : ICollection<TValue>
    {
        private Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();
        private SortedList<TOrder, TValue> _list = new SortedList<TOrder, TValue>();
        Func<TValue, TKey> _keySelector;
        Func<TValue, TOrder> _orderSelector;
    
        public SortedKeydCollection(Func<TValue, TKey> keySelector, Func<TValue, TOrder> orderSelector)
        {
            _keySelector = keySelector;
            _orderSelector = orderSelector;
        }
    
        #region ICollection<TValue> Members
    
        public void Add(TValue item)
        {
            _dict[_keySelector(item)] = item;
            _list[_orderSelector(item)] = item;
        }
    
        public void Clear()
        {
            _dict.Clear();
            _list.Clear();
        }
    
        public bool Contains(TValue item)
        {
            return _dict.ContainsKey(_keySelector(item));
        }
    
        public void CopyTo(TValue[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (TValue item in _list.Values) {
                if (i >= array.Length) {
                    break;
                }
                array[i++] = item;
            }
        }
    
        public int Count
        {
            get { return _list.Count; }
        }
    
        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<KeyValuePair<TOrder, TValue>>)_list).IsReadOnly ||
                       ((ICollection<KeyValuePair<TKey, TValue>>)_dict).IsReadOnly;
            }
        }
    
        public bool Remove(TValue item)
        {
            return _list.Remove(_orderSelector(item)) && _dict.Remove(_keySelector(item));
        }
    
        #endregion
    
        #region IEnumerable<TValue> Members
    
        public IEnumerator<TValue> GetEnumerator()
        {
            return _list.Values.GetEnumerator();
        }
    
        #endregion
    
        #region IEnumerable Members
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.Values.GetEnumerator();
        }
    
        #endregion
    }
