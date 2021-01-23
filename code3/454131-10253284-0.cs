    public static IEnumerable<T> Traverse<T>(this IEnumerable<T> enumerable, Func<T, IEnumerable<T>> recursivePropertySelector) {
        var stack = new Stack<IEnumerable<T>>();
        stack.Push(enumerable);
        while (stack.Count != 0) {
            enumerable = stack.Pop();
            foreach (T item in enumerable) {
                yield return item;
                var seqRecurse = recursivePropertySelector(item);
                if (seqRecurse != null) {
                    stack.Push(seqRecurse);
                }
            }
        }
    }
