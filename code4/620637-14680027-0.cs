    HtmlDocument page = new HtmlWeb().Load(url);
    var nodes = page.DocumentNode.SelectNodes("//div[@id='div1']//div[@class='h1']/text()");
    StringBuilder sb  = new StringBuilder();
    foreach(var node in nodes)
    {
       sb.Append(node.InnerText);
    }
    
    string content = sb.ToString();
