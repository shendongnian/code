    public static bool Remove(Category root, int id)
    {
        var stack = new Stack<Category>();
        stack.Push(root);
        while (stack.Any())
        {
            var next = stack.Pop();
            foreach (var child in next.ChildCategories)
            {
                if (child.Id == id)
                {
                    next.ChildCategories.Remove(child);
                    return true;
                }
                stack.Push(child);
            }
        }
        return false;
    }
