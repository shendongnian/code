    public static IEnumerable<(T, int[])> Expand<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getChildren) {
        var stack = new Stack<IEnumerator<T>>();
        var e = source.GetEnumerator();
        List<int> indexes = new List<int>() { -1 };
        try {
            while (true) {
                while (e.MoveNext()) {
                    var item = e.Current;
                    indexes[stack.Count]++;
                    yield return (item, indexes.Take(stack.Count + 1).ToArray());
                    var elements = getChildren(item);
                    if (elements == null) continue;
                    stack.Push(e);
                    e = elements.GetEnumerator();
                    if (indexes.Count == stack.Count)
                        indexes.Add(-1);
                    }
                if (stack.Count == 0) break;
                e.Dispose();
                indexes[stack.Count] = -1;
                e = stack.Pop();
            }
        } finally {
            e.Dispose();
            while (stack.Count != 0) stack.Pop().Dispose();
        }
    }
