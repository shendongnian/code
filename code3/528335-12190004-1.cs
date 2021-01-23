    public IEnumerable<T> GoodItems
    {
    	get
    	{
    		foreach (var item in GoodItemsHelper)
    			yield return item;
    	}
    }
    
    private IEnumerable<T> GoodItemsHelper
    {
    	get
    	{
    		foreach (var item in _list)
    			if (item.IsGood)
    				yield return item;
    	}
    }
