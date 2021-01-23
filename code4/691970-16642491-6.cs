    using HtmlAgilityPack;
    using Fizzler.Systems.HtmlAgilityPack;
    
    //get the page
    var web = new HtmlWeb();
    var document = web.Load("http://example.com/page.html")
    var page = document.DocumentNode;
    
    //loop through all div tags with item css class
    foreach(var item in page.QuerySelectorAll("div.item"))
    {
        var title = item.QuerySelector("h3:not(.share)").InnerText;
        var date = DateTime.Parse(item.QuerySelector("span:eq(2)").InnerText);
        var description = item.QuerySelector("span:has(b)").InnerHtml;
    }
