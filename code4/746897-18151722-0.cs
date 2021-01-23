    public static IEnumerable<Control> Traverse(this Control root)
    {
        var stack = new Stack<Control>();
        stack.Push(root);
        while (stack.Any())
        {
            var next = stack.Pop();
            foreach (Control children in next.Controls)
                stack.Push(children);
            yield return next;
        }
    }
