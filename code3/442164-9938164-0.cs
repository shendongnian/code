    WebBrowser web = new WebBrowser();
    web.DocumentCompleted += (sender, args) =>
        {
            var result = web.Document
                .GetElementsByTagName("input")
                .Cast<HtmlElement>()
                .Where(e => e.GetAttribute("name") == "ivcd_item")
                .Select(e=>e.GetAttribute("value"))
                .ToArray();
        };
    web.DocumentText = htmlstring;
