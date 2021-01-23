    public static bool IsEmptyElement(TreeNode node)
    {
        if (node.Type == TreeNode.NodeType.Category)
            return false;
        return node.Children.All(child => IsEmptyElement(child));
    }
