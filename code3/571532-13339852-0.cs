    HtmlElementCollection links = web.Document.GetElementsByTagName("a");
    foreach (HtmlElement link in links)
    {
        if (link.InnerText == "GoogleClick")
            MessageBox.Show(this, "Hooray I got it!");
    }
