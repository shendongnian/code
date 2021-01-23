    /// <summary> A class that will return one of the given items with a specified possibility. </summary>
    /// <typeparam name="T"> The type to return. </typeparam>
    /// <example> If the generator has only one item, it will always return that item. 
    /// If there are two items with possibilities of 0.4 and 0.6 (you could also use 4 and 6 or 2 and 3) 
    /// it will return the first item 4 times out of ten, the second item 6 times out of ten. </example>
    public class RandomNumerGenererator<T>
    {
        private List<Tuple<double, T>> _items = new List<Tuple<double, T>>();
    	private Random _random = new Random();
    
    	/// <summary>
    	/// All items possibilities sum.
    	/// </summary>
    	private double _totalPossibility = 0;
    
    	/// <summary>
    	/// Adds a new item to return.
    	/// </summary>
    	/// <param name="possibility"> The possibility to return this item. Is relative to the other possibilites passed in. </param>
    	/// <param name="item"> The item to return. </param>
    	public void Add(double possibility, T item)
    	{
    		_items.Add(new Tuple<double, T>(possibility, item));
    		_totalPossibility += possibility;
    	}
    
    	/// <summary>
    	/// Returns a random item from the list with the specified relative possibility.
    	/// </summary>
    	/// <exception cref="InvalidOperationException"> If there are no items to return from. </exception>
    	public T NextItem()
    	{
    		var rand = _random.NextDouble() * _totalPossibility;
    		double value = 0;
    		foreach (var item in _items)
    		{
    			value += item.Item1;
    			if (rand <= value)
    				return item.Item2;
    		}
    		return _items.Last().Item2; // Should never happen
    	}
    }
