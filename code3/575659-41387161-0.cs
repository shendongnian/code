    private HtmlAgilityPack.HtmlDocument RemoveScripts(HtmlAgilityPack.HtmlDocument webDocument)
    {
    // Get all Nodes: script
    HtmlAgilityPack.HtmlNodeCollection Nodes = webDocument.DocumentNode.SelectNodes("//script");
    // Make sure not Null:
    if (Nodes == null)
        return webDocument;
    foreach (HtmlNode node in Nodes)
        node.Remove();
    return webDocument;
    }
