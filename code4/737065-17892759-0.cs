    void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {    
        WebBrowser browser = sender as WebBrowser;
        browser.DocumentCompleted -= browser_DocumentCompleted;
        HtmlElementCollection imgCollection = browser.Document.GetElementsByTagName("img");
        WebClient webClient = new WebClient();
    
        foreach (HtmlElement img in imgCollection)
        {
            string url = img.GetAttribute("src");
            string name = System.IO.Path.GetFileName(url);
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, name);
            webClient.DownloadFile(url, path);
        }
    }
