    static class SortedListExtensions
    {
    	public static void Add<T>(this SortedList<T,T> list,T item)
    	{
    		list.Add(item,item);
    	}
		public static T Dequeue<T>(this SortedList<T,T> list)
		{
			var item=list.Keys.First();
			list.Remove(item);
			return item;
		}
		//and so on...
    }
