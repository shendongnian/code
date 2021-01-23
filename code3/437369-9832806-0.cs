    HtmlElement elem;
    if (webBrowser1.Document != null)
    {
        HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("HTML");
        if (elems.Count == 1)
        {
            elem = elems[0];
            string pageSource = elem.OuterHtml;
            File.WriteAllText(@"C:\doc.txt", pageSource, Encoding.UTF8);
        }
    }
