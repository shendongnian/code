    public static Tree GetParent(Tree root, string nodeId)
    {
        var stack = new Stack<Tree>();
        stack.Push(root);
        while (stack.Any())
        {
            var parent = stack.Pop();
            foreach (var child in parent.item)
            {
                if (child.id == nodeId)
                    return parent;
                stack.Push(child);
            }
        }
        return null;//not found
    }
