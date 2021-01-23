    private void button2_Click(object sender, EventArgs e)
        {
            string url = urlTextBox.Text;
            WebBrowser browser = new WebBrowser();
            browser.Navigate(url);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DownloadFiles);
        }
        private void DownloadFiles(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
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
                            string urlDownload = element.GetAttribute("src");
                            if (urlDownload != null && urlDownload.Length != 0)
                            {
                                WebClient wClient = new WebClient();
                                wClient.DownloadFile(urlDownload, "C:\\users\\folder\\location\\" + urlDownload.Substring(urlDownload.LastIndexOf('/')));
                            }
                        }
                    }
                }
            }
        }
    }
}
