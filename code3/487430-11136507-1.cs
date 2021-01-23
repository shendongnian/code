    partial class Dictionary<K,V>
    	where K: IComparable<K>
    	where V: IKeyProvider<K>, IPersistable
    {
    	...
    }
    partial class Dictionary<K,V>
    	where V: IPersistable, IKeyProvider<K>
    	where K: IComparable<K>
    {
    	...
    }
    partial class Dictionary<K,V>
    {
    	...
    }
