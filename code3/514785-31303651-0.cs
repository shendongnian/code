        public static IEnumerable<Tuple<T, int>> FlattenWithLevel<T>(
                this IEnumerable<T> items,
                Func<T, IEnumerable<T>> getChilds)
        {
            var stack = new Stack<Tuple<T, int>>();
            foreach (var item in items)
                stack.Push(new Tuple<T, int>(item, 1));
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                foreach (var child in getChilds(current.Item1))
                    stack.Push(new Tuple<T, int>(child, current.Item2 + 1));
            }
        }
