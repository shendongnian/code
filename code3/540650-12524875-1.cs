		public static T[] Add<T>(this T[] list, T item, bool checkUnique = false)
		{
			var tail = new [] { item, };
			var result = checkUnique ? list.Union(tail) : list.Concat(tail);
			return result.ToArray();
		}
