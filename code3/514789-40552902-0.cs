     public static class HierarchicalEnumerableUtils
        {
            private static IEnumerable<Tuple<T, int>> ToLeveled<T>(this IEnumerable<T> source, int level)
            {
                if (source == null)
                {
                    return null;
                }
                else
                {
                    return source.Select(item => new Tuple<T, int>(item, level));
                }
            }
    
            public static IEnumerable<Tuple<T, int>> FlattenWithLevel<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> elementSelector)
            {
                var stack = new Stack<IEnumerator<Tuple<T, int>>>();
                var leveledSource = source.ToLeveled(0);
                var e = leveledSource.GetEnumerator();
                try
                {
                    while (true)
                    {
                        while (e.MoveNext())
                        {
                            var item = e.Current;
                            yield return item;
                            var elements = elementSelector(item.Item1).ToLeveled(item.Item2 + 1);
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
        }
