    var doc = new HtmlDocument();
    doc.LoadHtml(yourHtmlInput);
    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]")
                                  ?? Enumerable.Empty<HtmlNode>())
    {
        string href = link.Attributes["href"].Value;
        if (!String.IsNullOrEmpty(href))
        {
            // Act on the link here, including ignoring it if it's a .jpg etc.
        }
    }
