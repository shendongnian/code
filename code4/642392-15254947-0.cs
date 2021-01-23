    public static void RemoveNodesRecursive(this MyNode node, Predicate<MyNode> predicate)
    {
        node.Children.RemoveAll(predicate);
        foreach (var n in node.Children)
        {
            RemoveNodes(n);
        }
    }
