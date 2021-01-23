    public static IEnumerable<MyNode> Traverse(this MyNode root)
    {
        var stack = new Stack<MyNode>();
        stack.Push(root);
        while(stack.Count > 0)
        {
            var current = stack.Pop();
            yield return current;
            foreach(var child in current.Elements)
                stack.Push(child);
        }
    }
