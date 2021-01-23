    private void AttachClickEventToInputs()
    {
          var htmlElements = webBrowser1.Document.GetElementsByTagName("input");
          for (int i = 0; i < htmlElements.Count; i++)
          {
              htmlElements[i].AttachEventHandler("onclick", (sender1, e1) => clickEventHandler(htmlElements[i], EventArgs.Empty));
          }
     }
