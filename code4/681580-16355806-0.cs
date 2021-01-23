    string currentGroup = null;
    List<TreeNode> treeNodes = new List<TreeNode>();
    List<TreeNode> childNodes = new List<TreeNode>();
    foreach (BusinessObject obj in objectList)
    {
        if (currentGroup == obj.Group)
            childNodes.Add(new TreeNode(obj.Name));
        else
        {
            if (childNodes.Count > 0)
            {
                treeNodes.Add(new TreeNode(currentGroup, childNodes.ToArray()));
                childNodes = new List<TreeNode>();
            }
            currentGroup = obj.Group;
        }
    }
    if (childNodes.Count > 0)
    {
        treeNodes.Add(new TreeNode(currentGroup, childNodes.ToArray()));
    }
    treeView.Nodes.AddRange(treeNodes.ToArray());
