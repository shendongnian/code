    TreeNode node = treeView1.SelectedNode;
    if (treeView1.SelectedNode != null)
    {
        if (treeView1.SelectedNode.Parent == null) 
            treeView1.SelectedNode.Remove();
        else if (treeView1.SelectedNode.Parent.Nodes.Count == 1) 
            treeView1.SelectedNode.Parent.Remove();
        else 
            treeView1.SelectedNode.Remove();
    }
    if(node != null)
    {
        XDocument doc = XDocument.Load("test.xml");
        var xElement = (from q in doc.Elements("dogs").Elements("dog")
                        where q.Attribute("id").Value == node.Tag.ToString()
                        select q);
        foreach (var a in xElement)
            a.Remove();
        doc.Save("test.xml");
    }
