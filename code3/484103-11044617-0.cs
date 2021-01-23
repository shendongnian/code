    static void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser browser = (WebBrowser)sender;
        HtmlElementCollection collection;
        List<HtmlElement> imgListString = new List<HtmlElement>();
        if (browser != null)
        {
            if (browser.Document != null)
            {
                collection = browser.Document.GetElementsByTagName("img");
                if (collection != null)
                {
                    foreach (HtmlElement element in collection)
                    {
                        WebClient wClient = new WebClient();
                        string urlDownload = element.GetAttribute("src");
                        wClient.DownloadFile(urlDownload, urlDownload.Substring(urlDownload.LastIndexOf('/')));
                    }
                }
            }
        }
    }
