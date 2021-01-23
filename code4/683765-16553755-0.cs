    public ScTreeNode GetNodeForState(int rootIndex, float[] inputs)
    {
        ScTreeNode node = RootNodes[rootIndex].TreeNode;
        while (node.BranchData != null)
        {
            BranchNodeData b = node.BranchData;
            node = b.Child2;
            if (inputs[b.SplitInputIndex] <= b.SplitValue))
                node = b.Child1;
        }
        return node;
    }
