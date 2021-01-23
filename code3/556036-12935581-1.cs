    HtmlElementCollection col=  webBrowser1.Document.GetElementsByTagName("input");
    HtmlElement wanted;
    foreach (HtmlElement item in col)
    {
        if (item.GetAttribute("value")=="type102")
        {
            wanted = item;
            break;
        }
    }
