    class Item
    {}
    
    void Main()
    {
    	var dictionary = new Dictionary<int, Item>();
    	dictionary[1] = new Item();
    	
    	Item i1;
    	Item i2;
    	
    	dictionary.TryGetValue(1, out i1);
    	dictionary.TryGetValue(1, out i2);
    	
    	Debug.Assert(object.ReferenceEquals(i1, i2));
    }
