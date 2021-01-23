    /// <summary>
    /// Removes all child nodes that do not have at least one Category as a child.
    /// </summary>
    /// <param name="node">The node to alter the children of.</param>
    /// <returns>True if there is at least one Category in this subtree</returns>
    public static bool RemoveEmptyElements(TreeNode node)
    {
        if (node.Type == TreeNode.NodeType.Category)
            return true;
        node.Children = node.Children.Where(child => RemoveEmptyElements(child))
                .ToList();
        return node.Children.Any();
    }
