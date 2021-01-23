	public static void ForEachBundle<T>(
		this IEnumerable<T> @this,
		Action<T, T, T> action)
	{
		if (@this == null) throw new System.ArgumentNullException("@this");
		var a = action;
		if (a == null) throw new System.ArgumentNullException("action");
		using (var en = @this.GetEnumerator())
		{
			while (en.MoveNext())
			{
				var t0 = en.Current;
				var t1 = en.MoveNext() ? en.Current : default(T);
				var t2 = en.MoveNext() ? en.Current : default(T);
				a(t0, t1, t2);
			}
		}
	}
