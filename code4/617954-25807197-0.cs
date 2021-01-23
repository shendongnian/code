    private List<string> SaveTreeState(TreeNodeCollection nodes)
    {
      List<string> nodeStates = new List<string>();
      foreach (TreeNode node in nodes)
      {
        if (node.IsExpanded) nodeStates.Add(node.Name);
        nodeStates.AddRange(SaveTreeState(node.Nodes));
      }
      return (nodeStates);
    }
