    //only one generic parameter needed, as key and value have same type.
    public class TwoWayDictionary<TKey> : IDictionary<TKey, TKey>
    {
      private Dictionary<TKey, TKey> _primary;
      private Dictionary<TKey, TKey> _secondary;
    
      public TwoWayDictionary()
      {
        _primary = new Dictionary<TKey, TKey>();
        _secondary = new Dictionary<TKey, TKey>();
      }
    
      public int Count {get{return _primary.Count;}}
      public bool IsReadOnly {get{return _primary.IsReadOnly;}}
      public TKey this[TKey key]
      {
        get
        {
          return this.GetValue(key);
        }
        set
        {
          this.Add(key, value);
        }
      }
      public ICollection<TKey> Keys {get {return _primary.Keys;}}
      public ICollection<TKey> Values {get {return _primary.Values;}}
    
      private TKey GetValue(TKey key)
      {
        if (_primary.ContainsKey(key))
        {
          return _primary[key];
        }
        if (_secondary.ContainsKey(key))
        {
          return _secondary[key];
        }
        throw new KeyNotFoundException("key is not found");
      }
    
      public void Add(KeyValuePair<TKey, TKey> item)
      {
        this.Add(item.Key, item.Value);
      }
    
      public void Add(TKey key, TKey value)
      {
        if (key == null || value == null)
        {
          throw new ArguementNullException("key or value is null");
        }
        if (_primary.ContainsKey(key) || _secondary.ContainsKey(key)
          || _primary.ContainsKey(value) || _secondary.ContainsKey(value))
        {
          throw new ArgumentException("Item with same key or value already exists");
        }
        _primary.Add(key, value);
        _secondary.Add(value, key);
      }
    
      public void Clear()
      {
        _primary.Clear();
        _secondary.Clear();
      }
    
      public void Contains(KeyValuePair<TKey, TKey> item)
      {
        return _primary.Contains(item) || _secondary.Contains(item);
      }
    
      public void ContainsKey(TKey key)
      {
        return _primary.ContainsKey(key) || _secondary.ContainsKey(key);
      }
    
      public void CopyTo(KeyValuePair<TKey, TKey>[] array, int arrayIndex)
      {
        return _primary.CopyTo(array, arrayIndex);
      }
    
    ... TODO finish implementing IDictionary
