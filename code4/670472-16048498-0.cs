    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load(filename); //or doc.LoadHtml(HtmlString)
    doc.DocumentNode.Descendants()
        .Where(n => n.Name == "script").ToList()
        .ForEach(s => s.Remove());
    StringWriter wr = new StringWriter();
    doc.Save(wr);
    var newhtml = wr.ToString();
