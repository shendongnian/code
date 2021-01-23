    public void navigateURL(string URL)
    {
    webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(page_Loaded);
    webBrowser1.Navigate(URL); 
    }
    void page_Loaded(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    MessageBox.Show(e.Url.AbsolutePath)
    }
