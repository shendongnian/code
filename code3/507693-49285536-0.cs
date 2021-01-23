    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
         foreach (HtmlElement _el in webBrowser1.Document.GetElementsByTagName("input"))
         {
             HtmlElement el = _el;
             el.AttachEventHandler("onclick", (sender1, e1) => clickEventHandler(el, EventArgs.Empty));
         }
    }
