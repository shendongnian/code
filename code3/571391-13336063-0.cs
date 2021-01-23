    private TreeNode[] GetNodes(DataTable table, int level = 1, string code = "")
    {
        return table.AsEnumerable()
                    .Where(row => row.Field<int>("liv") == level
                                  && row.Field<string>("cod").Contains(code))
                    .Select(row =>
                    {
                        var node = new TreeNode(row.Field<string>("des"));
                        node.Nodes.AddRange(GetNodes(table, level + 1, row.Field<string>("cod")));
                        return node;
                    })
                    .ToArray();
    }
