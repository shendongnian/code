    foreach (HtmlNode linkItem in doc.DocumentNode.SelectNodes("//table[3]/tr//a"))
    {
        Console.WriteLine(linkItem.Attributes["title"].Value());
        Console.WriteLine(linkItem.Attributes["alt"].Value());
    }
