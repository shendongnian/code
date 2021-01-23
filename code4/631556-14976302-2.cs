    public static IEnumerable<Node> Flatten(Node root)
    {
        foreach (var node in root.Children)
        {
            foreach (var child in Flatten(node))
            {
                yield return child;
            }
        }
        yield return root;
    }
