    public static int RemoveNodesButKeepChildren(this HtmlNode rootNode, string xPath)
    {
        HtmlNodeCollection nodes = rootNode.SelectNodes(xPath);
        if (nodes == null)
            return 0;
        foreach (HtmlNode node in nodes)
            node.RemoveButKeepChildren();
        return nodes.Count;
    }
    public static void RemoveButKeepChildren(this HtmlNode node)
    {
        foreach (HtmlNode child in node.ChildNodes)
            node.ParentNode.InsertBefore(child, node);
        node.Remove();
    }
    public static bool TestYourSpecificExample()
    {
        string html = "<p>my paragraph <div>and my <b>div</b></div> are <i>italic</i> and <b>bold</b></p>";
        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(html);
        document.DocumentNode.RemoveNodesButKeepChildren("//div");
        document.DocumentNode.RemoveNodesButKeepChildren("//p");
        return document.DocumentNode.InnerHtml == "my paragraph and my <b>div</b> are <i>italic</i> and <b>bold</b>";
    }
