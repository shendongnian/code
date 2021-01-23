    var doc = new HtmlDocument();
    
    using (var wc = new WebClient())
    using (var stream = wc.OpenRead(url))
    {
        doc.Load(stream);
    }
    var table = doc.DocumentElement.Element("html").Element("body").Element("table");
    string tableHtml = table.OuterHtml;
    
