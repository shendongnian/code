    public static IEnumerable<T> Closure<T>(
        T root, 
        Func<T, IEnumerable<T>> children)
    {
        var seen = new HashSet<T>();
        var stack = new Stack<T>();
        stack.Push(root);
       
        while(stack.Count != 0)
        {
            T item = stack.Pop();
            if (seen.Contains(item))
                continue;
            seen.Add(item);
            yield return item;
            foreach(var child in children(item))
                stack.Push(child);
        }
    }
