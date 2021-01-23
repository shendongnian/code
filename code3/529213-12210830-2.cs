    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
         Debug.WriteLine("documentCompleted");
         HtmlDocument doc = webBrowser1.Document;
         foreach (HtmlElement  imgElemt in doc.Images)
         {
             imgElemt.SetAttribute("src", "");
         }
    }
