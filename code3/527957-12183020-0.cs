    foreach (HtmlElement el in webBrowser1.Document.GetElementsByTagName("input")
    {
        if (el.GetAttribute("value").Equals("→"))
        {
            el.InvokeMember("click");
        }
    }
