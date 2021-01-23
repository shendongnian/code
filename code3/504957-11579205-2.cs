    static List<string> _notToRemove;
    static void Main(string[] args)
    {
        _notToRemove = new List<string>();
        _notToRemove.Add("br");
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml("<html><head></head><body><p>test</p><br><font><p><span></span></p></font></body></html>");
        RemoveEmptyNodes(doc.DocumentNode);
    }
    static void RemoveEmptyNodes(HtmlNode containerNode)
    {
        if (containerNode.Attributes.Count == 0 && !_notToRemove.Contains(containerNode.Name) && (containerNode.InnerText == null || containerNode.InnerText == string.Empty) )
        {
            containerNode.Remove();
        }
        else
        {
            for (int i = containerNode.ChildNodes.Count - 1; i >= 0; i-- )
            {
                RemoveEmptyNodes(containerNode.ChildNodes[i]);
            }
        }
    }
