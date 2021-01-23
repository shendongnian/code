    public static IEnumerable<Tuple<T, int>> TraverseWithDepth<T>(IEnumerable<T> items
        , Func<T, IEnumerable<T>> childSelector)
    {
        var stack = new Stack<Tuple<T, int>>(
            items.Select(item => Tuple.Create(item, 0)));
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return next;
            foreach (var child in childSelector(next.Item1))
            {
                stack.Push(Tuple.Create(child, next.Item2 + 1));
            }
        }
    }
