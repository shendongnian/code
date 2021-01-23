    items.RemoveAllByReference(item);
    public static void RemoveAllByReference<T>(this List<T> list, T item)
	{
        list.RemoveAll(x=> object.ReferenceEquals(x, item));
	}
    public static bool RemoveFirstByReference<T>(this List<T> list, T item)
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
    
