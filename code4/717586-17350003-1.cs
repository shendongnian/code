    private void PopulateTree(String path, TreeView view, TreeNode parent) {
      if (String.IsNullOrEmpty(path))
        return;
      int index = path.IndexOf(Path.DirectorySeparatorChar);
      String directoryName = (index < 0) ? path : path.Substring(0, index);
      String otherName = (index < 0) ? null : path.Substring(index + 1);
      TreeNode childNode = null;
      TreeNodeCollection nodes = (parent == null) ? view.Nodes : parent.Nodes;
      foreach (TreeNode node in nodes)
        if (String.Equals(node.Name, directoryName)) {
          childNode = node;
          break;
        }
      if (childNode == null)
        childNode = nodes.Add(directoryName);
      PopulateTree(otherName, view, childNode);
    }
    private void PopulateTree(IEnumerable<String> paths, TreeView view) {
      view.BeginUpdate();
      try {
        foreach (String path in paths)
          PopulateTree(path, view, null);
      }
      finally {
        view.EndUpdate();
      }
    }
    ...
    PopulateTree(ListWithPaths, MyTreeView)
