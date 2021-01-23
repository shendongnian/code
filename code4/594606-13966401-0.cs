    private void ProcessDocument(object sender,
        WebBrowserDocumentCompletedEventArgs e)
    {
         
        var webBrowser1 = (WebBrowser)sender;
    
        HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("A");
        foreach (HtmlElement link in links)
        {
            MessageBox.Show(link.InnerHtml);         
        }
    
    }
