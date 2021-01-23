    public class KeyValueItem<K,V>
    {
    	public K Key { get; set; }
    	public V Value { get; set; }
    
    	public override string ToString()
    	{
    		return this.Value.ToString(); // does not compile
    	}
    }
