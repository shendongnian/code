    private void WebBrowser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
    {
            System.Windows.Forms.WebBrowser browser = sender as System.Windows.Forms.WebBrowser;
            string title = browser.Document.Title;
            string description = String.Empty;
            foreach (HtmlElement meta in browser.Document.GetElementsByTagName("META"))
            {
                if (meta.Name.ToLower() == "description")
                {
                    description = meta.GetAttribute("content");
                }
            }
    }
