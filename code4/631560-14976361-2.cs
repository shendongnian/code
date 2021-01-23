    public IEnumerable<IContent> BuildContentFrom(IEnumerable<Node> nodes)
    {
        var stack= new Stack<Node>(nodes);
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return BuildContentFromSingle(next);
            foreach (var child in next.Children)
            {
                stack.push(child);
            }
        }
    }
        
