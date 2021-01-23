    public static IEnumerable<T> Traverse<T>(
        T root, 
        Func<T, IEnumerable<T>> children)
    {
        var stack = new Stack<T>();
        stack.Push(root);
        while(stack.Count != 0)
        {
            T item = stack.Pop();
            yield return item;
            foreach(var child in children(item))
                stack.Push(child);
        }
    }
