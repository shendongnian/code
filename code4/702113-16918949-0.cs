	public static T GetByIndex<T>(int index, params IList<T>[] lists){
		var minCount = lists.Min(l => l.Count);
		var minLists = lists.Where(l => l.Count == minCount).ToArray();
		if (index < minCount * lists.Length)
			return lists[index % lists.Length][index / lists.Length];
		else 
			return GetByIndex(index - minCount * minLists.Length, lists.Except(minLists).ToArray());
	}
    
    public static void SetByIndex<T>(int index, T val, params IList<T>[] lists){
		var minCount = lists.Min(l => l.Count);
		var minLists = lists.Where(l => l.Count == minCount).ToArray();
		if (index < minCount * lists.Length)
        {
			lists[index % lists.Length][index / lists.Length] = val;
		}
		else 
			SetByIndex(index - minCount * minLists.Length, val, lists.Except(minLists).ToArray());
	}
