        public static IEnumerable<T> TraverseDistinct<T>(this T enumer, Func<T, IEnumerable<T>> getChildren)
        {
            return new[] { enumer }.TraverseDistinct(getChildren);
        }
        public static IEnumerable<T> TraverseDistinct<T>(this IEnumerable<T> enumer, Func<T, IEnumerable<T>> getChildren)
        {
            HashSet<T> visited = new HashSet<T>();
            Stack<T> stack = new Stack<T>();
            foreach (var e in enumer)
            {
                stack.Push(e);
            }
            while (stack.Count > 0)
            {
                var i = stack.Pop();
                yield return i;
                visited.Add(i);
                var children = getChildren(i);
                if (children != null)
                {
                    foreach (var child in children)
                    {
                        if (!visited.Contains(child))
                        {
                            stack.Push(child);
                        }
                    }
                }
            }
        }
