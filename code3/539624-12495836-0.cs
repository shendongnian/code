	public static IEnumerable<Tuple<T1, IEnumerable<T2>>> ConditionalZip<T1, T2>(
		this IEnumerable<T1> src1,
		IEnumerable<T2> src2,
		Func<T1, T2, bool> check)
	{
		var list = new List<T2>();
		using(var enumerator = src2.GetEnumerator())
		{
			foreach(var item1 in src1)
			{
				while(enumerator.MoveNext())
				{
					var pickedItem = enumerator.Current;
					if(check(item1, pickedItem))
					{
						list.Add(pickedItem);
					}
					else
					{
						break;
					}
				}
				var items = list.ToArray();
				list.Clear();
				yield return new Tuple<T1, IEnumerable<T2>>(item1, items);
			}
		}
	}
