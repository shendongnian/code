    const string html = @"<span>İstanbul</span><ul><li><a href=""i1.htm"">Adana</a></li>";
    var doc = new HtmlDocument();
    doc.LoadHtml(html);
    string result = string.Join(" ", doc.DocumentNode.Descendants()
      .Where(n => !n.HasChildNodes && !string.IsNullOrWhiteSpace(n.InnerText))
      .Select(n => n.InnerText));
    Console.WriteLine(result); // prints "İstanbul Adana"
