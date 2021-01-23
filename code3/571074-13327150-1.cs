    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(responseFromServer);
    var names = doc.DocumentNode.SelectNodes("//a[@class='name']")
                    .Select(a=>a.InnerText)
                    .ToList();
    listBox1.DataSource = names;
