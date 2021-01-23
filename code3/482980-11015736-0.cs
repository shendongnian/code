    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(s);
    var elements = doc.DocumentNode.SelectNodes("//table[@class='table']");
    foreach (var ele in elements)
    {
        MessageBox.Show(ele.OuterHtml);
    }
