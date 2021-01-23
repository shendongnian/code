    using HtmlAgilityPack;
    using Fizzler.Systems.HtmlAgilityPack;
    var web = new HtmlWeb();
    var document = web.Load("some-url");
    var c = document.DocumentNode.QuerySelectorAll("div");
