    public static IEnumerable<Node> Flatten(Node root)
    {
        if (root != null)
        {
            foreach (var node in root.Children)
            {
                foreach (var child in Flatten(node))
                {
                    if (child != null)
                    {
                        yield return child;
                    }
                }
            }
            yield return root;
        }
    }
