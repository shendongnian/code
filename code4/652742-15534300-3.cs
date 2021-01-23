    webBrowser1.Navigating += new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
    webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
    private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    {
        if (e.Url.Contains("#")
        {
           string[] urlParts = e.Url.Split('#'); // split the string by character #
           string newUrl = urlParts[0];          // = myFile.html
           _somePrivateField = urlParts[1];      // = customAnchor
    
           webBrowser1.Navigate(new Uri(newUrl));
        }
    }
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        HtmlElementCollection elements = this.webBrowser1.Document.Body.All;
        foreach(HtmlElement element in elements){
           string nameAttribute = element.GetAttribute("Name");
           if(!string.IsNullOrEmpty(nameAttribute) && nameAttribute == _somePrivateField){
              element.ScrollIntoView(true);
              break;
           }
        }
    }
