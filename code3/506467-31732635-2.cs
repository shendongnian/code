		public static class ListExtensions
		{
			public static void MoveUp<T>(this IList<T> list, int index)
			{
				int newPosition = ((index > 0) ? index - 1 : list.Count - 1);
				var old = list[newPosition];
				list[newPosition] = list[index];
				list[index] = old;
			}
			public static void MoveDown<T>(this IList<T> list, int index)
			{
				int newPosition = ((index + 1 < list.Count) ? index + 1 : 0);
				var old = list[newPosition];
				list[newPosition] = list[index];
				list[index] = old;
			}
		}
