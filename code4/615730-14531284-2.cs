    private static void MarkSelectedNodes(TreeNodeCollection nodes)
    {
        Stack<TreeNode> toProcess =
            new Stack<TreeNode>(nodes.OfType<TreeNode>());
        while (toProcess.Count != 0)
        {
            TreeNode node = toProcess.Pop();
            if (node.Checked)
                node.BackColor = Color.Black;
            foreach (TreeNode child in node.Nodes)
                toProcess.Push(child);
        }
    }
