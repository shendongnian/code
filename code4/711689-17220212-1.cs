    HtmlElement textArea = webBrowser1.Document.All["textareaid"];
    if (textArea != null)
    {
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.Load(textArea.InnerText);
        foreach(HtmlAgilityPack.HtmlNode link in doc.DocumentElement.SelectNodes("//a[@href"])
        {
           HtmlAgilityPack.HtmlAttribute att = link["href"];
           webBrowser1.Navigate(att.Value);
        }
    }
