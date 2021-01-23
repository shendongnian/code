    items.RemoveByReference(item);
    public static bool RemoveByReference<T>(this List<T> list, T item)
	{
		var index = -1;
		for(int i = 0; i< list.Count; i++)
			if(object.ReferenceEquals(list[i], item))
			{
				index = i;
				break;
			}
		if(index == -1)
			return false;
		
		list.RemoveAt(index);
		return true;
	}
