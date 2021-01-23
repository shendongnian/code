	public static class MyEnumerableExtensions
	{
		public static IEnumerable<TFirst> NotReallyZip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TFirst> resultSelector)
		{
			using (var firstEnumerator = first.GetEnumerator())
			using (var secondEnumerator = second.GetEnumerator())
			{
				if (secondEnumerator.MoveNext())
				{
					if (firstEnumerator.MoveNext())
					{
						do yield return resultSelector(firstEnumerator.Current, secondEnumerator.Current);
						while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext());
					}
				}
				else
				{
					while (firstEnumerator.MoveNext())
						yield return firstEnumerator.Current;
				}
			}
		}
	}
