    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var font = doc.DocumentNode.Elements("font").FirstOrDefault();
    if (font != null)
    {
        string innerText = font.InnerText; //  "TSX Symbol Changes -December    17th - "December 21st
    }
