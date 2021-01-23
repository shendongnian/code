    public void ProcessPath(IEnumerable<String> path,  TreeNodeCollection nodes)
    {
        if (!path.Any())
            return;
        var node = nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == path.First());
        if (node == null)
        {
            node = new TreeNode(text: path.First());
            nodes.Add(node);
        }
        ProcessPath(path.Skip(1),node.ChildNodes);
    }
    public void CreateTreeView()
    {
        foreach (string field in MyDataBase.FieldsInMyColumn())
            ProcessPath(field.Split('\\'),myTreeView.Nodes);
    }
