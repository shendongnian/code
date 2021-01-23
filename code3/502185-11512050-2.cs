		/// <summary>
		/// Provides a way to get a distinct list of items based on a lambda comparison operator.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="equalityComparer">A comparison function that returns true of the two items are considered equal.</param>
		/// <returns>The list of distinct items.</returns>
		public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> equalityComparer)
		{
			var distincts = new List<T>();
			foreach (var item in source)
			{
				var found = false;
				foreach (var d in distincts)
				{
					found = equalityComparer(item, d);
					if (found)
						break;
				}
				if (!found)
				{
					distincts.Add(item);
					yield return item;
				}
			}
		}
