    public static TreeNode BuildTree(string tree)
    {
        var lines = tree.Split(new[] { Environment.NewLine },
                               StringSplitOptions.RemoveEmptyEntries);
        var result = new TreeNode("TreeRoot");
        var list = new List<TreeNode> { result };
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            var indent = line.Length - trimmedLine.Length;
            var child = new TreeNode(trimmedLine);
            list[indent].Add(child);
            if (indent + 1 < list.Count)
            {
                list[indent + 1] = child;
            }
            else
            {
                list.Add(child);
            }
        }
        return result;
    }
    public static string BuildString(TreeNode tree)
    {
        var sb = new StringBuilder();
        BuildString(sb, tree, 0);
        return sb.ToString();
    }
    private static void BuildString(StringBuilder sb, TreeNode node, int depth)
    {
        sb.AppendLine(node.ID.PadLeft(node.ID.Length + depth));
        foreach (var child in node)
        {
            BuildString(sb, child, depth + 1);
        }
    }
