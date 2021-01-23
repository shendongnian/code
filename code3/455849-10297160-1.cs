	public static class MyFunkyExtensions
	{
		public static IEnumerable<TResult> ZipThree<T1, T2, T3, TResult>(
			this IEnumerable<T1> source,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			Func<T1, T2, T3, TResult> func)
		{
			using (var e1 = source.GetEnumerator())
			using (var e2 = second.GetEnumerator())
			using (var e3 = third.GetEnumerator())
			{
				while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
					yield return func(e1.Current, e2.Current, e3.Current);
			}
		}
	}
