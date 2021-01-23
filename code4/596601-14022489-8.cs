    public string GetSelectionString()
    {
        string categorySep = Environment.NewLine;
        string parentChildSep = " : ";
        StringBuilder sb = new StringBuilder();
        foreach (TreeNode root in this.treeView1.Nodes)
        {
            foreach (TreeNode node in root.Nodes)
            {
                if (node.Checked)
                {
                    if (sb.Length > 0)
                        sb.Append(categorySep);
                    sb.Append(root.Text);
                    sb.Append(parentChildSep);
                    sb.Append(node.Text);
                    break;
                }
            }
        }
        return sb.ToString();
    }
