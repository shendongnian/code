    WebBrowser _browser;
    this._browser.DocumentCompleted+=new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
    ...
    private void browser_DocumentCompleted(Object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        this._browser.Document.Body.MouseDown += new HtmlElementEventHandler(Body_MouseDown);
    }
    ...
    void Body_MouseDown(Object sender, HtmlElementEventArgs e)
    {
        switch(e.MouseButtonsPressed)
        {
        case MouseButtons.Left:
            HtmlElement element = this._browser.Document.GetElementFromPoint(e.ClientMousePosition);
            if(element != null && "submit".Equals(element.GetAttribute("type"),StringComparison.OrdinalIgnoreCase)
            {
            }
        break;
        }
    }
