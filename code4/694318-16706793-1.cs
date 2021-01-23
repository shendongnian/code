    using HtmlAgilityPack;
    using Fizzler.Systems.HtmlAgilityPack;
    
    var web = new HtmlWeb();
    var document = web.Load("http://example.com/page.html")
    var page = document.DocumentNode;
    
    foreach(var item in page.QuerySelectorAll("a[href$='exe']"))
    {
        var file = item.Attributes["href"].Value;
    }
