    string myId = "foo";
    string myNewValue = "This goes in the Text Area!";
    IHTMLDocument2 htmlDoc = webBrowser1.Document.DomDocument as IHtmlDocument2;
    if (htmlDoc != null)
    {
      var textAreaType = typeof(IHTMLTextAreaElemnt);
      IHTMLTextAreaElement htmlTextArea = 
        htmlDoc.All
               .FirstOrDefault(x => textAreaType.IsAssignableFrom(x)
                                    && ((IHTMLElement)x).id == myId) 
               as IHTMLTextAreaElement;
      if (htmlTextArea != null)
      {
        htmlTextArea.value = myNewValue;
      }
    }
