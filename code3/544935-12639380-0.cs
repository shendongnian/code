    public static GenericListItem ToListItem<T>(this T obj, Func<T, string> textFunc, Func<T, int> idFunc)
    {
    	return new GenericListItem
    	{
    		Text = textFunc(obj),
    		Id = idFunc(obj)
    	};
    }
    
    public static List<GenericListItem> ToItemList<T>(this IEnumerable<T> seq, Func<T, string> textFunc, Func<T, int> idFunc)
    {
    	return seq.Select(i => i.ToListItem(textFunc, idFunc)).ToList();
    }
