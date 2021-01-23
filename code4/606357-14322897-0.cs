    HtmlDocument doc = new HtmlDocument();
    doc.Load(myHtmlFile);
    
    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class='lrg bold']"))
    {
        Console.WriteLine(node.InnerHtml);
    }
