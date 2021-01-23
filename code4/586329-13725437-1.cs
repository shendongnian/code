    private static IEnumerable<Node> GetNodes(Node root)
    {
        var result = Enumerable.Empty<Node>();
    
        if (root.left != null)
            result = result.Concat(GetNodes(root.left));
    
        result = result.Concat(new [] { root });
    
        if (root.right != null)
            result = result.Concat(GetNodes(root.right));
    
        return result;
    }
