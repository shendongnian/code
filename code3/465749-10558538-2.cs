    public class DictionaryIndexRetrievalCounter<TKey, TValue>
    {
    	private IDictionary<TKey, TValue> _dictionary;
    	private IList<TKey> _retrievedKeys;
    
    	public DictionaryIndexRetrievalCounter(IDictionary<TKey, TValue> dictionary)
    	{
    		this._dictionary = dictionary;
    		this._retrievedKeys = new List<TKey>();
    	}
    
    	public int GetIndex(TKey key)
    	{
    		if (!_retrievedKeys.Contains(key))
    		{
    			_retrievedKeys.Add(key);
    		}
    
    		return _retrievedKeys.IndexOf(key);
    	}
    }
