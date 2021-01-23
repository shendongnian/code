    public static void ActOnAllRecursively(this TreeNodeCollection nodes, Action<TreeNode> action)
    {
        foreach (TreeNode node in nodes)
        {
            ActOnRecursively(node, action);
        }
    }
    public static void ActOnRecursively(this TreeNode node, Action<TreeNode> action)
    {
        action(node);
        foreach (TreeNode node in node.Nodes)
        {
            ActOnRecursively(node);
        }
    }
