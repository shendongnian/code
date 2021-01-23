    public IEnumerable<IContentViewModel> BuildFrom(IEnumerable<NodeViewModel> nodes)
    {
        Stack<NodeViewModel> stack = new Stack<NodeViewModel>(nodes);
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return BuildFrom(next);
            foreach (var child in next.Children)
            {
                stack.Push(child);
            }
        }
    }
