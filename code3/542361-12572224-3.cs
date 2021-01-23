     var doc = new HtmlAgilityPack.HtmlDocument();
     doc.LoadHtml(Html);
     foreach(HtmlNode link in doc.DocumentElement.SelectNodes("//a[@href"])
     {
        var value = link.Attributes["href"].Value; //gives you the link
        var text = link.InnerText; //gives you the text of the link
     }
