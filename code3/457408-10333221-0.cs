	public static void ForEachBundle<T>(
		this IEnumerable<T> @this,
		Action<T, T, T> action)
	{
		if (@this == null) throw new System.ArgumentNullException("@this");
		var a = action;
		if (a == null) throw new System.ArgumentNullException("action");
		using (var en = @this.GetEnumerator())
		{
			while (true)
			{
				if (en.MoveNext())
				{
					var t0 = en.Current;
					if (en.MoveNext())
					{
						var t1 = en.Current;
						if (en.MoveNext())
						{
							var t2 = en.Current;
							a(t0, t1, t2);
						}
						else break;
					}
					else break;
				}
				else break;
			}
		}
	}
