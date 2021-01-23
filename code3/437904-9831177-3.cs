    private void AddParagraphToTree(Paragraph paragraph)
    {
        var sheetNode = AddNode(treeView.Nodes, paragraph.SheetName);
        var processNode = AddNode(sheetNode.Nodes, paragraph.Process);
        var materialNode = AddNode(processNode.Nodes, paragraph.Material);
        AddNode(materialNode.Nodes, paragraph.CutQuality);
    }
    private TreeNode AddNode(TreeNodeCollection nodes, string key)
    {
        if (!nodes.ContainsKey(key))
            nodes.Add(new TreeNode(key) { Name = key });
                    
        return nodes[key];
    }
