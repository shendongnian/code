    public static void ProcessTupleCollection<T>(this IEnumerable<T> collection) where T: ITuple
	{
		var type = typeof(T);
		var fields = type.GetFields();
		foreach (var item in collection)
		{
			foreach (var field in fields)
			{
				field.GetValue(item);
			}
		}
	}
