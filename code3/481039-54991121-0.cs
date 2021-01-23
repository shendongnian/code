    public class BijectiveDictionary<TKey, TValue> 
    {
    	private EqualityComparer<TKey> _keyComparer;
    	private Dictionary<TKey, ISet<TValue>> _forwardLookup;
    	private EqualityComparer<TValue> _valueComparer;
    	private Dictionary<TValue, ISet<TKey>> _reverseLookup;             
    
    	public BijectiveDictionary()
    		: this(EqualityComparer<TKey>.Default, EqualityComparer<TValue>.Default)
    	{
    	}
    
    	public BijectiveDictionary(EqualityComparer<TKey> keyComparer, EqualityComparer<TValue> valueComparer)
    		: this(0, EqualityComparer<TKey>.Default, EqualityComparer<TValue>.Default)
    	{
    	}
    
    	public BijectiveDictionary(int capacity, EqualityComparer<TKey> keyComparer, EqualityComparer<TValue> valueComparer)
    	{
    		_keyComparer = keyComparer;
    		_forwardLookup = new Dictionary<TKey, ISet<TValue>>(capacity, keyComparer);            
    		_valueComparer = valueComparer;
    		_reverseLookup = new Dictionary<TValue, ISet<TKey>>(capacity, valueComparer);            
    	}
    
    	public void Add(TKey key, TValue value)
    	{
    		AddForward(key, value);
    		AddReverse(key, value);
    	}
    
    	public void AddForward(TKey key, TValue value)
    	{
    		ISet<TValue> values;
    		if (!_forwardLookup.TryGetValue(key, out values))
    		{
    			values = new HashSet<TValue>(_valueComparer);
    			_forwardLookup.Add(key, values);
    		}
    		values.Add(value);
    	}
    
    	public void AddReverse(TKey key, TValue value) 
    	{
    		ISet<TKey> keys;
    		if (!_reverseLookup.TryGetValue(value, out keys))
    		{
    			keys = new HashSet<TKey>(_keyComparer);
    			_reverseLookup.Add(value, keys);
    		}
    		keys.Add(key);
    	}
    
    	public bool TryGetReverse(TValue value, out ISet<TKey> keys)
    	{
    		return _reverseLookup.TryGetValue(value, out keys);
    	}
    
    	public ISet<TKey> GetReverse(TValue value)
    	{
    		ISet<TKey> keys;
    		TryGetReverse(value, out keys);
    		return keys;
    	}
    
    	public bool ContainsForward(TKey key)
    	{
    		return _forwardLookup.ContainsKey(key);
    	}
    
    	public bool TryGetForward(TKey key, out ISet<TValue> values)
    	{
    		return _forwardLookup.TryGetValue(key, out values);
    	}
    
    	public ISet<TValue> GetForward(TKey key)
    	{
    		ISet<TValue> values;
    		TryGetForward(key, out values);
    		return values;
    	}
    
    	public bool ContainsReverse(TValue value)
    	{
    		return _reverseLookup.ContainsKey(value);
    	}
    
    	public void Clear()
    	{
    		_forwardLookup.Clear();
    		_reverseLookup.Clear();
    	}
    }
