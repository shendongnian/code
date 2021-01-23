    // after the document loaded
    webBrowser1.Document.MouseMove += Document_MouseMove;
    //On document mouse move, set the current Element
    HtmlElement curElement;
    void Document_MouseMove(object sender, HtmlElementEventArgs e)
    {
        curElement = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
    }
    // Now you have the clicked element
    void webBrowser1_NewWindow(object sender, CancelEventArgs e)
    {
        e.Cancel = true;
        if (curElement != null && curElement.TagName == "A")
        {
            string href = curElement.GetAttribute("href");
            // do whatever
        }
    }
