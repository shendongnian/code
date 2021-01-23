    List<string>oddStrings = new List<string>();
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(html);
    foreach (HtmlNode ul in doc.DocumentNode.Descendants("ul"))
    {
        HtmlNode nextSibling = ul.NextSibling;
        if (nextSibling != null && nextSibling.NodeType == HtmlNodeType.Text)
        {
            string trimmedText = nextSibling.InnerText.Trim();
            if (!String.IsNullOrEmpty(trimmedText))
            {
                oddStrings.Add(trimmedText);
            }
        }
    }
