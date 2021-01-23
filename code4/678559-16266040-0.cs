    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var innerText = doc.DocumentNode
                       .SelectSingleNode("//div[@class='topheader-left common-txt']")
                       .InnerText;
    DateTime time = DateTime.ParseExact(WebUtility.HtmlDecode(innerText).Split('|')[1].Trim(), 
                                        "hh:mm:ss tt",
                                        CultureInfo.InvariantCulture);
