    HtmlDocument doc = new HtmlWeb().Load("http://www.google.com");
    List<string> words = doc.DocumentNode.DescendantNodes()
            .Where(n => n.NodeType == HtmlNodeType.Text
              && !string.IsNullOrWhiteSpace(HtmlEntity.DeEntitize(n.InnerText))
              && n.ParentNode.Name != "style" && n.ParentNode.Name != "script")
            .Select(n => HtmlEntity.DeEntitize(n.InnerText).Trim())
            .Where(s => s.Length > 2).ToList();
