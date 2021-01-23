    WebBrowser wbc = new WebBrowser();
    wbc.DocumentText = "foo"; // necessary to create the document
    HtmlDocument doc = wbc.Document.OpenNew(true);
    doc.Write((string)html); // insert your html-string here
    List<class1> elements = wbc.Document.GetElementsByTagName("li").Cast<HtmlElement>()
        .Where(li => li.Children.Count == 2)
        .Select(outerLi => new class1
        {
            parent = outerLi.FirstChild.InnerText,
            children = outerLi.Children.Cast<HtmlElement>()
                .Last().Children.Cast<HtmlElement>()
                .Select(innerLi => innerLi.FirstChild.InnerText).ToList()
        }).ToList();
