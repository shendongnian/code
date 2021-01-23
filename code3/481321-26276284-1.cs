 	public static IEnumerable<T> Interleave<T>(this IEnumerable<IEnumerable<T>> source)
   	{
   		var enumerators = source.Select(e => e.GetEnumerator()).ToArray();
   		try
   		{
   			bool itemsRemaining;
   			do
   			{
   				itemsRemaining = false;
   				foreach (var item in 
                         enumerators.Where(e => e.MoveNext()).Select(e => e.Current))
   				{
   					yield return item;
   					itemsRemaining = true;
   				}
   			}
   			while (itemsRemaining);
   		}
   		finally
   		{
   			Array.ForEach(enumerators, e => e.Dispose());
   		}
   	}
