    public static IEnumerable<TreeNodeAdv> CollectExpandedNodes(this TreeNodeAdv root)
    {
        Stack<TreeNodeAdv> s = new Stack<TreeNodeAdv>();
        s.Push(root);
        while (s.Count > 0)
        {
            TreeNodeAdv n = s.Pop();
    
            if (n.IsExpanded)
                yield return n;
    
            foreach (var child in n.Children.ToArray().Reverse())
            {
                s.Push(child);
            }
        }
    }
