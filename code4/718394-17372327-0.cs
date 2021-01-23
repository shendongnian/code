    public static IEnumerable<Category> Traverse(Category root)
    {
        var stack = new Stack<Category>();
        stack.Push(root);
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return next;
            foreach (var child in next.ChildCategories)
                stack.Push(child);
        }
    }
