		public static void TraverseAndExecute<T>(this IEnumerable<T> items, Func<T, IEnumerable<T>> selector, Action<T> actionToExecute)
		{
			if (items != null)
			{
				foreach (T item in items)
				{
					actionToExecute(item);
					TraverseAndExecute(selector(item), selector, actionToExecute);
				}
			}
		}
