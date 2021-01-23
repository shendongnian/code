    HtmlDocument doc = new HtmlDocument();
    doc.Load(MyTestHtm);
    HtmlNode body = doc.DocumentNode.SelectSingleNode("//body");
    if (body == null)
    {
        HtmlNode html = doc.DocumentNode.SelectSingleNode("//html");
        // we presume html exists
    
        body = CloneAsParentNode(html.ChildNodes, "body");
    }
    static HtmlNode CloneAsParentNode(HtmlNodeCollection nodes, string name)
    {
        List<HtmlNode> clones = new List<HtmlNode>(nodes);
        HtmlNode parent = nodes[0].ParentNode;
    
        // create a new parent with the given name
        HtmlNode newParent = nodes[0].OwnerDocument.CreateElement(name);
    
        // insert before the first node in the selection
        parent.InsertBefore(newParent, nodes[0]);
    
        // clone all sub nodes
        foreach (HtmlNode node in clones)
        {
            HtmlNode clone = node.CloneNode(true);
            newParent.AppendChild(clone);
        }
    
        // remove all sub nodes
        foreach (HtmlNode node in clones)
        {
            parent.RemoveChild(node);
        }
        return newParent;
    }
