	public static void SortList<T>(List<T> dataSource, string fieldName, SortDirection sortDirection)
	{
		PropertyInfo propInfo = typeof(T).GetProperty(fieldName);
		Comparison<T> compare = delegate(T a, T b)
		{
			bool asc = sortDirection == SortDirection.Ascending;
			object valueA = asc ? propInfo.GetValue(a, null) : propInfo.GetValue(b, null);
			object valueB = asc ? propInfo.GetValue(b, null) : propInfo.GetValue(a, null);
			if(valueA == null)
			{
				if(valueB == null)
				{
					return 0;
				}
				else
				{
					return asc ? -1 : 1;
				}
			}
			if(valueB == null)
			{
				return asc ? 1 : -1;
			}
			return valueA is IComparable ? ((IComparable)valueA).CompareTo(valueB) : 0;
		};
		dataSource.Sort(compare);
	}
