    HtmlDocument doc = new HtmlDocument();
    doc.Load(MyTestFile);
    
    foreach(var node in doc.DocumentNode.SelectNodes("//div[@id='playerStats']/div/span"))
    {
        Console.WriteLine(node.InnerText + " " + (node.NextSibling != null ? node.NextSibling.InnerText : null));
    }
