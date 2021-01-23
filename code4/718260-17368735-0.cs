    public List(IEnumerable<T> collection)
    {
    	if (collection == null)
    	{
    		ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
    	}
    	ICollection<T> collection2 = collection as ICollection<T>;
    	if (collection2 != null)
    	{
    		int count = collection2.Count;
    		this._items = new T[count];
    		collection2.CopyTo(this._items, 0);
    		this._size = count;
    		return;
    	}
    	this._size = 0;
    	this._items = new T[4];
    	using (IEnumerator<T> enumerator = collection.GetEnumerator())
    	{
    		while (enumerator.MoveNext())
    		{
    			this.Add(enumerator.Current);
    		}
    	}
    }
