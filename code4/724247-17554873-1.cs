    public static void RemoveNode(Tree root, string nodeId)
    {
        var parent = GetParent(root, nodeId).item
            .RemoveAll(child => child.id == nodeId);
    }
