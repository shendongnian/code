    public IEnumerable<T> GoodItems
    {
    	get
    	{
    		foreach (var item in _list)
    			if (item.IsGood)
    				yield return item;
    	}
    }
    
