    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(text);
    var nodes = doc.DocumentNode.SelectNodes("//p");
    StringBuilder result = new StringBuilder();
    result.Append("<p>");
    foreach (HtmlNode node in nodes)
    {
        result.Append(node.InnerHtml);
    }
    result.Append("</p>");
