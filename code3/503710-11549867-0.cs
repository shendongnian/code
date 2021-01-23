    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(yourHtml);
    
    //This will get all div's with class as label
    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='label']"))
    {
        Console.WriteLine("InnerText=" + node.InnerText);
        Console.WriteLine();
    }
    
    //This will get all div's with class as value
    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='value']"))
    {
        Console.WriteLine("InnerText=" + node.InnerText);
        Console.WriteLine();
    }
 
