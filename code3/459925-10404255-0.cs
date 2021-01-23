	public class Element
	{
		public string Key { get; set; }
		public string Property { get; set; }
		public Element CreateCopy()
		{
			return new Element
			{
				Key = this.Key,
				Property = this.Property,
			};
		}
	}
---
	var d = new ConcurrentDictionary<string, Element>();
	// thread 1
	// prune
	foreach ( var kv in d )
	{
		if ( kv.Value.Property == "ToBeRemoved" )
		{
			Element dummy = null;
			d.TryRemove( kv.Key, out dummy );
		}
	}
	// thread 1
	// add
	Element toBeAdded = new Element();
	// set basic properties here
	d.TryAdd( toBeAdded.Key, toBeAdded );
	// thread 2
	// populate element
	Element unPopulated = null;
	if ( d.TryGetValue( "ToBePopulated", out unPopulated ) )
	{
		Element nowPopulated = unPopulated.CreateCopy();
		nowPopulated.Property = "Populated";
		
		// either
		d.TryUpdate( unPopulated.Key, nowPopulated, unPopulated );
		// or
		d.AddOrUpdate( unPopulated.Key, nowPopulated, ( key, value ) => nowPopulated );
	}
	// read threads
	// enumerate
	foreach ( Element element in d.Values )
	{
		// do something with each element
	}
	// read threads
	// try to get specific element
	Element specific = null;
	if ( d.TryGetValue( "SpecificKey", out specific ) )
	{
		// do something with specific element
	}
