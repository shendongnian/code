    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    TreeNode root = new TreeNode("HTML");
    treeView1.Nodes.Add(root);
    LoadTree(root, doc.DocumentNode);
    void LoadTree(TreeNode treeNode, HtmlAgilityPack.HtmlNode rootNode)
    {
        foreach (var node in rootNode.ChildNodes)
        {
            TreeNode n = new TreeNode(node.Name);
            treeNode.Nodes.Add(n);
            LoadTree(n, node);
        }
    }
