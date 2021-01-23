		public static IEnumerable<T> Expand<T>(
			this IEnumerable<T> source, Func<T, IEnumerable<T>> elementSelector)
		{
			var stack = new Stack<IEnumerator<T>>();
			var e = source.GetEnumerator();
			try
			{
				while (true)
				{
					while (e.MoveNext())
					{
						var item = e.Current;
                        yield return item;
						var elements = elementSelector(item);
						if (elements == null) continue;
						stack.Push(e);
						e = elements.GetEnumerator();
					}
					if (stack.Count == 0) break;
					e.Dispose();
					e = stack.Pop();
				}
			}
			finally
			{
				e.Dispose();
				while (stack.Count != 0) stack.Pop().Dispose();
			}
		}
