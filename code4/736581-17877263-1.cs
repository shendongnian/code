    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(html);
    foreach(HtmlNode node in doc.DocumentElement.SelectNodes("//*").Where(x=>x.InnerText==""))
    {
           node.ParentNode.ReplaceChild(HtmlTextNode.CreateNode(input), node);
    }
    doc.Save(yourFile);
