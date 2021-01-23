    HtmlDocument doc= new HtmlDocument();
    
    doc.Load(@"C:\..\page.html");
    
    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a");
    
    foreach (HtmlNode node in nodes)
    {
        try
        {
            Console.WriteLine(node.Attributes["href"].Value);
        }
        catch (Exception) { }
    }
