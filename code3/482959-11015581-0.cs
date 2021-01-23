    public TreeNode AddPluginNode(TreeNode parent, AbstractEnvChecker plugin)
    {
      TreeNode created = new TreeNode(plugin.Name) { Tag = plugin };
      parent.Nodes.Add(created);
      return created;
    }
