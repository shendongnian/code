    public static void RemoveComments(HtmlNode node)
    {
        foreach (var n in node.ChildNodes.ToArray())
            RemoveComments(n);
        if (node.NodeType == HtmlNodeType.Comment)
            node.Remove();
    }
