    private void PopulateTree(String path, TreeNode parent, int depth) {
      if (depth == 0) // <- Artificial criterium
        return;
      if (String.IsNullOrEmpty(path))
        return;
      int index = path.IndexOf(Path.DirectorySeparatorChar);
      String directoryName = (index < 0) ? path : path.Substring(0, index);
      String otherName = (index < 0) ? null : path.Substring(index + 1);
      TreeNode childNode = parent.Nodes.Add(directoryName);
      PopulateTree(otherName, childNode, depth - 1);
    }
