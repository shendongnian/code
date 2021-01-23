    private void AttachClickEventToInputs()
    {
         var htmlElements = webBrowser1.Document.GetElementsByTagName("input");
         for (int i = 0; i < htmlElements.Count; i++)
         {
              HtmlElement el = htmlElements[i];
              el.AttachEventHandler("onclick", (sender1, e1) => clickEventHandler(el, EventArgs.Empty));
         }
    }
