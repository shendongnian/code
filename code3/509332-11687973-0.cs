    public int FindIndex(int startIndex, int count, Predicate<T> match)
    {
    	if (startIndex > this._size)
    	{
    		ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
    	}
    	if (count < 0 || startIndex > this._size - count)
    	{
    		ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
    	}
    	if (match == null)
    	{
    		ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
    	}
    	int num = startIndex + count;
    	for (int i = startIndex; i < num; i++)
    	{
    		if (match(this._items[i]))
    		{
    			return i;
    		}
    	}
    	return -1;
    }
